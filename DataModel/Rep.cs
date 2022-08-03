using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weather_info.Interface;
using weather_info.DataModel;

namespace weather_info.DataModel
{
    class Rep : IRep<WeatherRequest>
    {
        private string ConnectionString { get; set; }

        public string City { get; set; }

        public Rep(string connectionString)
        {
            ConnectionString = connectionString;

        }

        public void Add()
        {
            string sqlExpression = "INSERT INTO Cities (Name, Count) VALUES (@name, @count)";
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);

                SqliteParameter nameParam = new SqliteParameter("@name", SqliteType.Text, 20);

                nameParam.Value = City;

                command.Parameters.Add(nameParam);

                SqliteParameter countParam = new SqliteParameter("@count", Counter());

                command.Parameters.Add(countParam);

                int number = command.ExecuteNonQuery();
            }
        }

        public void Clear()
        {
            string sqlExpression = "Drop table Cities";
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);

                int number = command.ExecuteNonQuery();

                Console.WriteLine($"Table deleted.");
            }
            Create();
        }

        public int Counter()
        {
            int res = 1;
            string sqlExpression = $"SELECT * FROM Cities WHERE Name=@name";            

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);

                SqliteParameter nameParam = new SqliteParameter("@name", SqliteType.Text, 20);

                nameParam.Value = City;

                command.Parameters.Add(nameParam);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res++;
                        }
                    }
                    return res;
                }
            }
        }

        public void Create()
        {
            try
            {
                using (var connection = new SqliteConnection(ConnectionString))
                {
                    connection.Open();

                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = "CREATE TABLE Cities(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Count INTEGER NOT NULL)";
                    command.ExecuteNonQuery();

                    Console.WriteLine("Table is created");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error, table is already exists!");
                throw;
            }
        }

        public void PrintTable()
        {
            string sqlExpression = "SELECT * FROM Cities";
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Id  \t City  \t      total");
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            var id = reader.GetValue(0);
                            var name = reader.GetValue(1);
                            var count = reader.GetValue(2);


                            Console.WriteLine($"{id}  \t{name}    \t{count}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No results...");
                    }
                }
            }
        }
        public List<WeatherRequest> GetArray()
        {
            int counter = 1;
            List<WeatherRequest> requests = new List<WeatherRequest>();
            string sqlExpression = "SELECT * FROM Cities";
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            object id = reader.GetValue(0);
                            object name = reader.GetValue(1);
                            object count = reader.GetValue(2);

                            requests.Add(new WeatherRequest
                            {
                                Id = (long)id,
                                City = (string)name,
                                Count = (long)count
                            });
                            counter++;
                        }
                    }
                    return requests;
                }
            }
        }
    }
}
