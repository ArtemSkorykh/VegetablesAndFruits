using Microsoft.Win32.SafeHandles;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace VegetablesAndFruits
{
    internal class Program
    {

        public static string StrConn => @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VegetablesAndFruits;Integrated Security=True;Connect Timeout=30;";
        private SqlConnection _conn;


        void DisplayOfAllInformation()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = "SELECT * FROM VegetablesAndFruits";
                var cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]} {reader["Name"]} {reader["Type"]} {reader["Color"]} {reader["Kcal"]}");
                    }

                }

                conn.Close();
            }
        }
       void DisplayOfAllNames()
       {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = "SELECT DISTINCT VegetablesAndFruits.Name FROM VegetablesAndFruits";
                var cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]}");
                    }

                }

                conn.Close();
            }
       }
       void DisplayAllColors()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = "SELECT DISTINCT VegetablesAndFruits.Color FROM VegetablesAndFruits";
                var cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Color"]}");
                    }

                }

                conn.Close();
            }
        }
        void DisplayTheMaximumCalorie()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = "SELECT MAX(Kcal) FROM VegetablesAndFruits";
                var cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string str = reader[0].ToString();
                        Console.WriteLine(str);
                    }

                }

                conn.Close();
            }
        }
        void DisplayTheMinimumCalorie()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = "SELECT MIN(Kcal) FROM VegetablesAndFruits";
                var cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string str = reader[0].ToString();
                        Console.WriteLine(str);
                    }

                }

                conn.Close();
            }
        }
        void DisplayTheAverageCalorie()
        {
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = "SELECT AVG(Kcal) FROM VegetablesAndFruits";
                var cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string str = reader[0].ToString();
                        Console.WriteLine(str);   
                    }

                }

                conn.Close();
            }
        }





        static void Main(string[] args)
        {

            var Program = new Program();

            int i = 2;
            while (i != 0)
            {
                Console.WriteLine("Enter the comand \n1 - connect | 0 - exit\n");
                Console.Write("Comand: ");
                i = Int32.Parse(Console.ReadLine());

                if (i == 1)
                {
                    using (SqlConnection conn = new SqlConnection(StrConn))
                    {
                        conn.Open();

                        if(conn.State == System.Data.ConnectionState.Closed)
                        {
                            i = 0;
                            Console.WriteLine("Database wasn't opened!");

                        }
                        Console.WriteLine();
                        Console.WriteLine("Database opened succsesful!");
                        conn.Close();
                    }
                    

                    i = 0;
                }
            }


           

        }
    }
}
