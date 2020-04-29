using System;

namespace TinyCRMConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var products = Product.GetProductsFromCSV(@"\Data\Products.csv");

            var uniqueProducts = Product.ProductUniqueFilter(products);

            foreach (var product in uniqueProducts)
            {
                Console.WriteLine(product);
            }

        }
    }
}
