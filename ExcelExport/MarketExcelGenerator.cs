using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using weather_info.DataModel;

namespace weather_info.ExcelExport
{
    internal class MarketExcelGenerator
    {
        public byte[] Generate(List<WeatherRequest> city)
        {
            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets
                .Add("Market Report");
            

            sheet.Cells[2, 2, 2, 4].LoadFromArrays(new object[][] { new[] { "ID", "City", "Total" } });
            var row = 3;
            var column = 2;
            foreach (var item in city)
            {
                sheet.Cells[row, column].Value = item.Id;
                sheet.Cells[row, column + 1].Value = item.City;
                sheet.Cells[row, column + 2].Value = item.Count;
                row++;
            }

            sheet.Cells[1, 1, row, column + 2].AutoFitColumns();
            sheet.Column(2).Width = 10;
            sheet.Column(3).Width = 12;


            sheet.Cells[2, 2, 2 + city.Count, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            sheet.Cells[2, 2, 2, 4].Style.Font.Bold = true;

            sheet.Cells[2, 2, 2, 4].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[2, 2, 2, 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            sheet.Cells[2, 2, 2 + city.Count, 4].Style.Border.BorderAround(ExcelBorderStyle.Double);
            sheet.Cells[2, 2, 2, 4].Style.Fill.SetBackground(OfficeOpenXml.Drawing.eThemeSchemeColor.Accent6);


            return package.GetAsByteArray();
        }
    }
}
