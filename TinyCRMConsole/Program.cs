using System;

namespace TinyCRMConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var products = Product.GetProductsFromCSV(@"\Data\Products.csv");

                var uniqueProducts = Product.ProductUniqueFilter(products);

                uniqueProducts.ForEach(product => Console.WriteLine(product));
            
            }
            catch (Exception)
            {
                return;
            }



        }
    }
}
