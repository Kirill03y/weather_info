using System;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace weather
{
 
    internal class Program
    {

        static void Main(string[] args)
        {

            string url = $"https://api.openweathermap.org/data/2.5/weather?q=dnipro&units=metric&appid=c57b785c5640a2b106649cc53c220a62";

            //var res = new WebClient().DownloadString(url);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }


            
        }
    }
}