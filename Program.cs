﻿using System;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using weather_info;
using weather_info.DataModel;
using OfficeOpenXml;

namespace weather
{
 
     class Program
    {

        static void Main(string[] args)
        {
            string connectionString = "Data Source=usersdata.db";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Rep repository = new Rep(connectionString);

            bool flag = true;
            while (flag)
            {
                try
                {
                    Console.WriteLine("_______________________________________________________________________________\n" +
                        "1 - Find weather / 2 - Requests history / 3 - Clear requests / 4 - Export .xlsx");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Enter city: ");
                            string city = Console.ReadLine();

                            Methods.SearchWeather(city, repository);
                            repository.Add();
                            break;

                        case 2:
                            repository.PrintTable();
                            break;

                        case 3:
                            repository.Clear();
                            break;
                        case 4:
                            Methods.GenerateExcel(repository);
                            break;

                        default:
                            Console.WriteLine("Enter 1 - 3");
                            break;
                    }
                    

                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect choise. Enter 1 - 3 !");
                }
                catch (WebException)
                {
                    Console.WriteLine("Incorrect Name. Try again");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);                
                }
            }
            

        }
    }
}