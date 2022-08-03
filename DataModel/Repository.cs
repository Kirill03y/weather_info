//using Microsoft.Data.Sqlite;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace weather_info.DataModel
//{
//    class Repository
//    {
//        public static void Create()
//        {
//            try
//            {
//                using (var connection = new SqliteConnection("Data Source=usersdata.db"))
//                {
//                    connection.Open();

//                    SqliteCommand command = new SqliteCommand();
//                    command.Connection = connection;
//                    command.CommandText = "CREATE TABLE Cities(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Count INTEGER NOT NULL)";
//                    command.ExecuteNonQuery();

//                    Console.WriteLine("Table is created");
//                }
//            }
//            catch (Exception)
//            {
//                Console.WriteLine("Error, table is already exists!");
//                throw;
//            }
           
            
//        }
//        public static void Add(string city)
//        {       
//            string sqlExpression = "INSERT INTO Cities (Name, Count) VALUES (@name, @count)";
//            using (var connection = new SqliteConnection("Data Source=usersdata.db"))
//            {
//                connection.Open();

//                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                
//                SqliteParameter nameParam = new SqliteParameter("@name", SqliteType.Text, 20);
                
//                nameParam.Value = city;
                
//                command.Parameters.Add(nameParam);
                
//                SqliteParameter countParam = new SqliteParameter("@count", Counter(city));
                
//                command.Parameters.Add(countParam);

//                int number = command.ExecuteNonQuery();
//            }          
//        }
//        public static int Counter(string city)
//        {
//            int res = 1;
//            string sqlExpression = $"SELECT * FROM Cities WHERE Name='{city}'";

//            using (var connection = new SqliteConnection("Data Source=usersdata.db"))
//            {
//                connection.Open();

//                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
//                using (SqliteDataReader reader = command.ExecuteReader())
//                {
//                    if (reader.HasRows)
//                    {
//                        while (reader.Read())
//                        {
//                            res++;
//                        }                       
//                    }
//                    return res;
//                }
//            }
//        }
//        public static void PrintTable()
//        {
//            string sqlExpression = "SELECT * FROM Cities";
//            using (var connection = new SqliteConnection("Data Source=usersdata.db"))
//            {
//                connection.Open();

//                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
//                using (SqliteDataReader reader = command.ExecuteReader())
//                {
//                    Console.WriteLine("--------------------------------");
//                    Console.WriteLine("Id  \t City  \t      total");
//                    if (reader.HasRows) 
//                    {
                        
//                        while (reader.Read())
//                        {
//                            var id = reader.GetValue(0);
//                            var name = reader.GetValue(1);
//                            var count = reader.GetValue(2);
                            
                            
//                            Console.WriteLine($"{id}  \t{name}    \t{count}");
//                        }
//                    }
//                    else
//                    {
//                        Console.WriteLine("No results...");
//                    }
//                }
//            }
//        }
//        public static void Clear()
//        {
//            string sqlExpression = "Drop table Cities";
//            using (var connection = new SqliteConnection("Data Source=usersdata.db"))
//            {
//                connection.Open();

//                SqliteCommand command = new SqliteCommand(sqlExpression, connection);

//                int number = command.ExecuteNonQuery();

//                Console.WriteLine($"Deleted.");
//            }
//            Create();
//        }
//    }
//}
