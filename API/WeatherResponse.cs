﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather_info
{
    class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }

        public SunInfo Sys { get; set; }

        public string Name { get; set; }
    }
}
