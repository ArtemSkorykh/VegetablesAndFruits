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
            Console.Clear();
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
                Console.ReadLine();
                Console.Clear();
            }
        }
       void DisplayOfAllNames()
       {
            Console.Clear();
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
                Console.ReadLine();
                Console.Clear();
            }
       }
       void DisplayAllColors()
        {
            Console.Clear();
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
                Console.ReadLine();
                Console.Clear();
            }
        }
        void DisplayTheMaximumCalorie()
        {
            Console.Clear();
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
                Console.ReadLine();
                Console.Clear();
            }
        }
        void DisplayTheMinimumCalorie()
        {
            Console.Clear();
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
                Console.ReadLine();
                Console.Clear();
            }
        }
        void DisplayTheAverageCalorie()
        {
            Console.Clear();
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
                Console.ReadLine();
                Console.Clear();
            }
        }





        static void Main(string[] args)
        {

            var Program = new Program();

            int i = -1;
            while (i != 0)
            {
                Console.Clear();
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
                        conn.Close();
                    }

                    Console.Clear();
                    Console.WriteLine("Database opened succsesful!\n");
                    
                    int j = -1;
                    while (j != 0)
                    {
                        Console.WriteLine("Enter the comand \n1 - Display Of All Information  | 2 - Display Of All Names        | 3 - Display All Colors");
                        Console.WriteLine("4 - Display The Maximum Calorie | 5 - Display The Minimum Calorie | 6 - Display The Average Calorie\n0 - Exit\n");
                        Console.Write("Comand: ");
                        j = Int32.Parse(Console.ReadLine());
                        switch(j)
                        {
                            case 1: Program.DisplayOfAllInformation();
                                break;
                            case 2:
                                Program.DisplayOfAllNames();
                                break;
                            case 3:
                                Program.DisplayAllColors();
                                break;
                            case 4:
                                Program.DisplayTheMaximumCalorie();
                                break;
                            case 5:
                                Program.DisplayTheMinimumCalorie();
                                break;
                            case 6:
                                Program.DisplayTheAverageCalorie();
                                break;
                            default:
                                j = 0;
                                break;
                        } 
                    }
                    i = -1;
                }
            }


           

        }
    }
}
