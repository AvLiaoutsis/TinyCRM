using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRMConsole
{
    class Program
    {
        static void CustomAdd(string key, int count, Dictionary<string, int> mydict)
        {
            if (mydict.TryAdd(key, count))
            {
                if (!mydict.ContainsKey(key))
                {
                    mydict.Add(key, count);

                }
            }
        }
        static List<string> MostSoldProducts(List<Order> orders)
        {
            var productBySales = new Dictionary<string, int>();

            foreach (var order in orders)
            {
                var countPerProduct = order.Products.GroupBy(p => p.Name).Select(g => new { g.Key, Count = g.Count() }).ToList();

                countPerProduct.ForEach(x => CustomAdd(x.Key,x.Count, productBySales));
  
            }

            var top5products = productBySales.OrderBy(x => x.Value).Take(5).Select(x => x.Key).ToList();

            return top5products;
                
        }

        static void Main(string[] args)
        {
            List<Product> products;
            List<Order> totalOrders = new List<Order>();


            try
            {
                products = Product.GetProductsFromCSV(@"\Data\Products.csv");

            
            }
            catch (Exception)
            {
                return;
            }


            var uniqueProducts = Product.ProductUniqueFilter(products);

            //uniqueProducts.ForEach(product => Console.WriteLine(product));

            //1st Customer
            var customerA = new Customer("Avraam","Liaoutsis","Av.liaoutsis@outlook.com","123456789","6979090123",0,true,24);

            //2nd Customer
            var customerB = new Customer("Alex", "Liaoutsis", "Al.liaoutsis@outlook.com", "123456788", "6979090123", 0, true, 24);

            //Create first order for Customer A
            var orderA = new Order();

            //10 random products for first Order
            var randomAProducts = uniqueProducts.OrderBy(x => new Random().Next()).Take(10).ToList();

            orderA.Products.AddRange(randomAProducts);
            orderA.CalculateAmmount();

            //Assign to Customer A

            customerA.Orders.Add(orderA);
            totalOrders.Add(orderA);

            //Create first order for Customer B

            var orderB = new Order();

            //10 random products for first Order
            var randomBProducts = uniqueProducts.OrderBy(x => new Random().Next()).Take(10).ToList();

            orderB.Products.AddRange(randomBProducts);
            orderB.CalculateAmmount();

            //Assign to Customer B

            customerB.Orders.Add(orderB);
            totalOrders.Add(orderB);




            Console.WriteLine("The most valuable customer is " + Customer.MostValuable(customerA,customerB));

            Console.WriteLine("The most Sold orders are the following :" );

            MostSoldProducts(totalOrders).ForEach(o => Console.WriteLine(o));
        }
    }
}
