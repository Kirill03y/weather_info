using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using weather_info.DataModel;

namespace weather_info
{
    class Methods
    {
        static string responseWeather(string city)
        {

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=c57b785c5640a2b106649cc53c220a62";

            //var res = new WebClient().DownloadString(url);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string res;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                res = streamReader.ReadToEnd();
            }
            return res;
        }
        public static void SearchWeather(string city, Rep repository)
        {
            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseWeather(city));

            DateTime sRise = new DateTime(1970, 1, 1).Add(TimeSpan.FromTicks(weatherResponse.Sys.Sunrise * TimeSpan.TicksPerSecond)).ToLocalTime();
            DateTime sSet = new DateTime(1970, 1, 1).Add(TimeSpan.FromTicks(weatherResponse.Sys.Sunset * TimeSpan.TicksPerSecond)).ToLocalTime();

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Temperature in {0}, {1} °C\nsunrise - {2}, sunset - {3}\n",
                weatherResponse.Name, weatherResponse.Main.Temp, sRise.ToLongTimeString(), sSet.ToLongTimeString());

            repository.City = weatherResponse.Name;
            

            //Repository.Add(weatherResponse.Name);
        }
    }
}
