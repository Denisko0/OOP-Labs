using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        
        SqlConnection connection = new SqlConnection("<connection string>");
        connection.Open();

        
        string query = "SELECT * FROM Products";
        SqlCommand command = new SqlCommand(query, connection);

        
        SqlDataReader reader = command.ExecuteReader();

        
        var groupedData = reader.Cast<System.Data.Common.DbDataRecord>()
                                .GroupBy(r => r["Category"])
                                .Select(g => new {
                                    Category = g.Key,
                                    Products = g.Select(r => r["ProductName"])
                                });

        
        foreach (var group in groupedData)
        {
            Console.WriteLine("Category: " + group.Category);
            foreach (var productName in group.Products)
            {
                Console.WriteLine("- " + productName);
            }
            Console.WriteLine();
        }

        
        reader.Close();
        connection.Close();
    }
}