using System;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace weather
{
 
    internal class Program
    {
        public static async Task ConnectAsync()
        {
            WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={c57b785c5640a2b106649cc53c220a62}");
            request.Method = "POST";
            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }
            response.Close();
        }
        class task{

        }
        static void Main(string[] args)
        {

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dnipro}&appid={c57b785c5640a2b106649cc53c220a62}";
            var res = new WebClient().DownloadString(url);




            
        }
    }
}