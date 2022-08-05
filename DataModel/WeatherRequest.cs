using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather_info.DataModel
{
    class WeatherRequest
    {
        public int Id { get; set; }   
        public string City { get; set; }
        public int Count { get; set; }
    }
}
