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
        
        static void Main(string[] args)
        {
            bool flag = true;

            while (flag)
            {
                try
                {

                    Console.WriteLine("-------------------------------------------------------------\n" +
                        "1 - Find weather / 2 - Requests history / 3 - Clear requests");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Enter city: ");
                            string city = Console.ReadLine();
                            Methods.Print(city);
                            break;
                        case 2:
                            Repository.PrintTable();
                            break;
                        case 3:
                            Repository.Clear();
                            break;

                        default:
                            Console.WriteLine("Enter 1 - 3");
                            break;
                    }
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    
                }
            }
            

        }
    }
}