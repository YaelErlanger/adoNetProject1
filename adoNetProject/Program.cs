using System;
using System.Data.SqlClient;
using System.Data;


namespace adoNetProject
{
    public class Program
    {

        

       
        static void Main(string[] args)
        {


            Access ac = new Access();
            Console.WriteLine("hello");
            string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog = Store_326659356; Integrated Security = True";
            
            string RqueryString = "select * from Products_tbl";
            string IqueryString = "insert into Products_tbl (ProductName,Description,CategoryId,price,image) values (@ProductName,@Description,@CategoryId,@price,@image)";

            ac.InsertDate(IqueryString, connectionString);
            ac.ReadData(RqueryString, connectionString);


        }

    }
}
