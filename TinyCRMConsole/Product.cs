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


            var DataToObjects = File.ReadAllLines(path + filename)
                  .Skip(1)
                  .Select(x => x.Split(';'))
                  .Select(x => new Product
                  {
                     ProductId = x[0],
                     Name = x[1],
                     Description = x[2],
                     Price = (decimal)Math.Round(new Random().NextDouble() * 100 , 3)
                  })
                  .ToList();


            return DataToObjects;
        }
        public static List<Product> ProductUniqueFilter(List<Product> givenData)
        {
            var data = givenData.GroupBy(d => d.ProductId)
                .Select(d => d.First())
                .ToList();

            return data;
        }
        public override string ToString()
        {
            return 
                $"Product ID = {this.ProductId } " +
                $"Product Name = {this.Name} , " +
                $"Product Description = {this.Description} , " +
                $"Product Price = {this.Price} " + "\n";
        }
    }

}
