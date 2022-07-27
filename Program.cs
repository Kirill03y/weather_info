using System;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using weather_info;
using weather_info.DataModel;


namespace weather
{
 
     class Program
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
        static void Print(string city)
        {
            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseWeather(city));

            DateTime sRise = new DateTime(1970, 1, 1).Add(TimeSpan.FromTicks(weatherResponse.Sys.Sunrise * TimeSpan.TicksPerSecond)).ToLocalTime();
            DateTime sSet = new DateTime(1970, 1, 1).Add(TimeSpan.FromTicks(weatherResponse.Sys.Sunset * TimeSpan.TicksPerSecond)).ToLocalTime();


            Console.WriteLine("Temperature in {0}, {1} °C\nsunrise - {2}, sunset - {3}\n",
                weatherResponse.Name, weatherResponse.Main.Temp, sRise.ToLongTimeString(), sSet.ToLongTimeString());

            Repository.Add(weatherResponse.Name);
        }
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                try
                {

                    Console.WriteLine("Enter City: ");
                    string city = Console.ReadLine();

                    Print(city);

                    //Repository.Create();

                    Repository.PrintTable();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    
                }
            }
            

        }
    }
}