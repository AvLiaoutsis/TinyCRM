using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRMConsole
{
    class Program
    {
        static List<Customer> SearchCustomers(CustomerOptions options)
        {
            var db = new TinyCrmDbContext();

            var customerList = db.Set<Customer>()
                .Where(c => c.FirstName.Contains(options.FirstName) ||
                c.LastName.Contains(options.LastName) ||
                c.VatNumber.Contains(options.VatNumber) ||
                (options.CreatedTo < c.Created && options.CreateFrom < c.Created) ||
                c.Id.ToString().Contains(options.CustomerId.ToString()))
                .Take(500)
                .ToList();

            return customerList;
        }

        static List<Product> SearchProducts(ProductOptions options)
        {
            var db = new TinyCrmDbContext();

            var customerList = db.Set<Product>()
                .Where(c => c.ProductId.ToString().Contains(options.ProductId.ToString()) ||
                (c.Price > options.PriceFrom && c.Price < options.PriceTo) ||
                options.Categories.Any(ca => ca.Contains(c.ProductCategory)))
                .Take(500)
                .ToList();
                

            return customerList;
        }

        static void Main(string[] args)
        {

            var db = new TinyCrmDbContext();

            // Insert
            var customer = new Customer()
            {
                FirstName = "Avraam",
                LastName = "Liaoutsis",
                Email = "Av.liaoutsis@outlook.com"
            };

            db.Add(customer);
            db.SaveChanges();



        }
    }
}
