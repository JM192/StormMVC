namespace TestingProject
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using DataAccessLayer;
    using BusinessLogicLayer;

    /// <summary>
    /// AUTHOR: John McGillis
    /// COMPANY: Onshore Outsourcing
    /// DESCRIPTION: Program for testing projects
    /// </summary>

    class Program
    {
        static void MainSystemDotData(string[] args)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection())
            {
                connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StormTech Database;Integrated Security=True";
                connection.Open();
                using (SqlCommand command = new SqlCommand("Sp_ReadAllGames", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader r = command.ExecuteReader())
                    {
                        Console.WriteLine($"HasRows={r.HasRows} FieldCount={r.FieldCount}");
                        for (int i = 0; i < r.FieldCount; i++)
                        {
                            Console.WriteLine($"{i}: Name:{r.GetName(i)} Type:{r.FieldCount}");
                        }
                        while (r.Read())
                        {
                            Console.WriteLine(r["GameID"]);
                            Console.WriteLine(r["Game_Title"]);
                            Console.WriteLine(r["Purchase_Price"]);
                            Console.WriteLine(r["Release_Date"]);
                            Console.WriteLine();
                        }
                    }
                }
                using (SqlCommand command = new SqlCommand("Sp_ReadAllOrders", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader r = command.ExecuteReader())
                    {
                        Console.WriteLine($"HasRows={r.HasRows} FieldCount={r.FieldCount}");
                        for (int i = 0; i < r.FieldCount; i++)
                        {
                            Console.WriteLine($"{i}: Name:{r.GetName(i)} Type:{r.FieldCount}");
                        }
                        while (r.Read())
                        {
                            Console.WriteLine(r["Order_Num"]);
                            Console.WriteLine(r["Order_Name"]);
                            Console.WriteLine(r["Purchase_Date"]);
                            Console.WriteLine();
                        }
                    }
                }
                using (SqlCommand command = new SqlCommand("Sp_ReadAllRoles", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader r = command.ExecuteReader())
                    {
                        Console.WriteLine($"HasRows={r.HasRows} FieldCount={r.FieldCount}");
                        for (int i = 0; i < r.FieldCount; i++)
                        {
                            Console.WriteLine($"{i}: Name:{r.GetName(i)} Type:{r.FieldCount}");
                        }
                        while (r.Read())
                        {
                            Console.WriteLine(r["RoleID"]);
                            Console.WriteLine(r["Name"]);
                            Console.WriteLine(r["Role_Type"]);
                            Console.WriteLine(r["Privilege"]);
                            Console.WriteLine();
                        }
                    }
                }
                using (SqlCommand command = new SqlCommand("Sp_ReadAllUpdates", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader r = command.ExecuteReader())
                    {
                        Console.WriteLine($"HasRows={r.HasRows} FieldCount={r.FieldCount}");
                        for (int i = 0; i < r.FieldCount; i++)
                        {
                            Console.WriteLine($"{i}: Name:{r.GetName(i)} Type:{r.FieldCount}");
                        }
                        while (r.Read())
                        {
                            Console.WriteLine(r["UpdateID"]);
                            Console.WriteLine(r["Patch"]);
                            Console.WriteLine(r["Expansion"]);
                            Console.WriteLine(r["Add_Ons"]);
                            Console.WriteLine();
                        }
                    }
                }
                using (SqlCommand command = new SqlCommand("Sp_ReadAllUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader r = command.ExecuteReader())
                    {
                        Console.WriteLine($"HasRows={r.HasRows} FieldCount={r.FieldCount}");
                        for (int i = 0; i < r.FieldCount; i++)
                        {
                            Console.WriteLine($"{i}: Name:{r.GetName(i)} Type:{r.FieldCount}");
                        }
                        while (r.Read())
                        {
                            Console.WriteLine(r["UserID"]);
                            Console.WriteLine(r["F_name"]);
                            Console.WriteLine(r["L_name"]);
                            Console.WriteLine(r["Address"]);
                            Console.WriteLine(r["Ph_num"]);
                            Console.WriteLine(r["Email"]);
                            Console.WriteLine(r["Username"]);
                            Console.WriteLine(r["Password"]);
                            Console.WriteLine(r["Role"]);
                            Console.WriteLine(r["News_sub"]);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        static void MainDataAccessLayer()
        {
            using (DALContext ctx = new DALContext())
            {
                ctx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StormTech Database;Integrated Security=True";

                var items = ctx.ReadAllUsers();
                foreach(UsersDAL r in items)
                {
                    Console.WriteLine(r);
                }

                Console.WriteLine("******************");
                Console.Write("Enter a Username: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var found = ctx.ReadSpecificUser(id);
                if (found == null)
                {
                    Console.WriteLine("Nothing was Found");
                }
                else
                {
                    Console.WriteLine(found);
                }
            }
        }

        static void Main()
        {
            using (BLLContext ctx = new BLLContext())
            {
                foreach (var item in ctx.GetAllUsers())
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}