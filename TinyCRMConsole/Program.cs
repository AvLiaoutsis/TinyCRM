using System;

namespace TinyCRMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string startupPath = Environment.CurrentDirectory;
            Console.WriteLine(startupPath);
            var Products = Product.GetProductsFromCSV(@"\Data\Products.csv");

            foreach (var product in Products)
            {
                Console.WriteLine(product.Price);
            }

        }
    }
}
