using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TinyCRMConsole
{
    class Product
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string Name { get; set; }




        public static List<Product> GetProductsFromCSV(string filename)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));

            var r = new Random();

            var Data = File.ReadAllLines(path + filename)
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new Product
                {
                    ProductId = x[0],
                    Name = x[1],
                    Description = x[2],
                    Price = Math.Round(r.Next(1, 400) / Convert.ToDecimal(r.Next(1, 20)),3)
                }).ToList();


            return Data;

        }
    }

}
