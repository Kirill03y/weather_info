using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather_info.DataModel
{
    class WeatherRequest
    {
        public long Id { get; set; }   
        public string City { get; set; }
        public long Count { get; set; }
    }
}
