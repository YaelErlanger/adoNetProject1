﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoNetProject
{
    public class Access
    {

        public  void InsertDate(string IqueryString, string connectionString)
        {
            string ProductName, Description,image;
            int price, CategoryId;
            string next = "y";
            while (next == "y")
            {
                Console.WriteLine("insert productName: ");
                ProductName = Console.ReadLine();
                Console.WriteLine("insert Description: ");
                Description = Console.ReadLine();
                Console.WriteLine("insert CategoryId: ");
                CategoryId =  Convert.ToInt32( Console.ReadLine());
                Console.WriteLine("insert image: ");
                image = Console.ReadLine();
                Console.WriteLine("insert price: ");
                price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("do you want to insert more product? (y/n)");
                next = Console.ReadLine();
               //try
               // {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(IqueryString, connection);
                        command.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = ProductName;
                        command.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
                        command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
                    command.Parameters.Add("@price", SqlDbType.Int).Value = price;
                    command.Parameters.Add("@image", SqlDbType.VarChar).Value = image;

                    command.Connection.Open();
                        int x = command.ExecuteNonQuery();
                        Console.WriteLine(x);
                    }
               // }
                //catch (er)
                //{
                //    Console.WriteLine(er);
                //}

            }

           

        }
        public  void ReadData(string RqueryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(RqueryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3),reader.GetInt32(4), reader.GetString(5));
                    }
                }
                else
                {
                    Console.WriteLine("no data founded");
                }
                reader.Close();
            }
        }
    }
}
