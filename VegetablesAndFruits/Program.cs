using Microsoft.Win32.SafeHandles;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System;

namespace VegetablesAndFruits
{
    internal class Program
    {

        public static string StrConn => @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VegetablesAndFruits;Integrated Security=True;Connect Timeout=30;";
        private SqlConnection _conn;

        //// #3
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

        //// #4
        void DisplayNumberOfVegetables()
        {
            Console.Clear();
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = "SELECT COUNT(VegetablesAndFruits.Id) FROM VegetablesAndFruits WHERE VegetablesAndFruits.Type = 'vegetable'";
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

        void DisplayNumberOfFruits()
        {
            Console.Clear();
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = "SELECT COUNT(VegetablesAndFruits.Id) FROM VegetablesAndFruits WHERE VegetablesAndFruits.Type = 'fruit'";
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

        void DisplayNumberOfGivenColor()
        {
            Console.Clear();

            string str;
            Console.Write("Enter the color: ");
            str = Console.ReadLine();

            Console.WriteLine();

            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = $"SELECT * FROM VegetablesAndFruits WHERE VegetablesAndFruits.color = @cl";
                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@cl", str);

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
        void DisplayNumbersOfEveryColor()
        {
            Console.Clear();
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = "SELECT VegetablesAndFruits.Color, VegetablesAndFruits.Type, COUNT(*) AS 'Number' FROM VegetablesAndFruits GROUP BY VegetablesAndFruits.Color, VegetablesAndFruits.Type";
                var cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Color"]} {reader["Type"]} {reader["Number"]}");
                    }

                }

                conn.Close();
                Console.ReadLine();
                Console.Clear();
            }
        }

        void DisplayWithCaloriesBelow()
        {
            Console.Clear();

            float f;
            Console.Write("Enter the kcal: ");
            f = float.Parse(Console.ReadLine());

            Console.WriteLine();


            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = $"SELECT * FROM VegetablesAndFruits WHERE VegetablesAndFruits.Kcal < @f";
                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@f", f);

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
        void DisplayWithCaloriesHigher()
        {
            Console.Clear();

            float f;
            Console.Write("Enter the kcal: ");
            f = float.Parse(Console.ReadLine());

            Console.WriteLine();


            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = $"SELECT * FROM VegetablesAndFruits WHERE VegetablesAndFruits.Kcal > @f";
                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@f", f);

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
        void DisplayWithcalorieContentInTheIndicatedRange()
        {
            Console.Clear();

            float f1;
            Console.Write("Enter the first kcal: ");
            f1 = float.Parse(Console.ReadLine());

            Console.WriteLine();

            float f2;
            Console.Write("Enter the second kcal: ");
            f2 = float.Parse(Console.ReadLine());

            Console.WriteLine();


            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = $"SELECT * FROM VegetablesAndFruits WHERE VegetablesAndFruits.Kcal > @f1 AND VegetablesAndFruits.Kcal < @f2";
                var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@f1", f1);
                cmd.Parameters.AddWithValue("@f2", f2);

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

        void DisplayAllYellowOrRedColor()
        {
            Console.Clear();
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                conn.Open();
                var query = "SELECT * FROM VegetablesAndFruits WHERE VegetablesAndFruits.Color = 'red' OR VegetablesAndFruits.Color = 'yellow'";
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
                        Console.WriteLine("Enter the comand \n1 - Display Of All Information              | 2 - Display Of All Names         | 3 - Display All Colors");
                        Console.WriteLine("4 - Display The Maximum Calorie             | 5 - Display The Minimum Calorie  | 6 - Display The Average Calorie");
                        Console.WriteLine("7 -  Display Number Of Vegetables           | 8 - Display Number Of Fruits     | 9 - Display Number Of Plants Of Given Color");
                        Console.WriteLine("10 - Display Numbers Of Every Color         | 11 - Display With Calories Below | 12 - Display With Calories Higher");
                        Console.WriteLine("13 - Display All Plants Yellow Or Red Color | 14 - Display With Calorie Content In The Indicated Range");
                        Console.WriteLine("0 - Exit");

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
                            case 7:
                                Program.DisplayNumberOfVegetables();
                                break;
                            case 8:
                                Program.DisplayNumberOfFruits();
                                break;
                            case 9:
                                Program.DisplayNumberOfGivenColor();
                                break;
                            case 10:
                                Program.DisplayNumbersOfEveryColor();
                                break;
                            case 11:
                                Program.DisplayWithCaloriesBelow();
                                break;
                            case 12:
                                Program.DisplayWithCaloriesHigher();
                                break;
                            case 13:
                                Program.DisplayAllYellowOrRedColor();
                                break;
                            case 14:
                                Program.DisplayWithcalorieContentInTheIndicatedRange();
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
