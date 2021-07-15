using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperProductRepository(conn);
            var products = repo.GetAllProducts();
            repo.CreateProduct("TV", 400, 5);
            
            foreach(var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");
            }

            

        }
    }
}
