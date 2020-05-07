using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRMConsole
{
    class Program
    {

        static IQueryable<Customer> SearchCustomers(SearchCustomerOptions options,TinyCrmDbContext db)
        {
            if (options == null)
            {
                throw new ArgumentNullException("Null options");
            }



                var customerList = db.Set<Customer>()
                    .Where(c => c.FirstName.Contains(options.FirstName) ||
                    c.LastName.Contains(options.LastName) ||
                    c.VatNumber.Contains(options.VatNumber) ||
                    (options.CreatedTo >= c.Created && options.CreateFrom >= c.Created) ||
                    c.Id.ToString().Contains(options.CustomerId.ToString()))
                    .Take(500);

                return customerList;

            
        }

        static IQueryable<Product> SearchProducts(ProductOptions options)
        {

            using (var db = new TinyCrmDbContext())
            {
                var customerList = db.Set<Product>()
                .Where(c => c.ProductId.ToString().Contains(options.ProductId.ToString()) ||
                (c.Price >= options.PriceFrom && c.Price <= options.PriceTo))
                .Take(500);


                return customerList;
            }
        }

        static void Main(string[] args)
        {

            using (var db = new TinyCrmDbContext())
            {

                // Insert
                //var customer = new Customer()
                //{
                //    FirstName = "Avraam",
                //    LastName = "Liaoutsis",
                //    Email = "Av.liaoutsis@outlook.com"
                //};

                //db.Add(customer);
                //db.SaveChanges();

                var firstOptionCustomer = new SearchCustomerOptions()
                {
                    FirstName = "Avraam",

                };

                var secondOptionCustomer = new SearchCustomerOptions()
                {
                    FirstName = "Avraam"

                };


                var thirdOptionCustomer = new SearchCustomerOptions()
                {
                    FirstName = "Avraam"

                };




                var product = new Product()
                {
                    Category = ProductCategory.Mobiles,
                    Name = "Iphone 15",
                    Price = 1500m
                };

                db.Add(product);
                db.SaveChanges();

                // one to many 
                var customerWithOrders = new Customer()
                {
                    FirstName = "Avraam",
                    LastName = "Liaoutsis",
                    Email = "Av.liaoutsis@outlook.com"

                };


                customerWithOrders.Orders.Add
                (
                    new Order()
                    {
                        DeliveryAddress = " ATHINA",
                    }
                 );

                db.Add(customerWithOrders);
                db.SaveChanges();

                // Select customer with orders
                var customer = SearchCustomers(new SearchCustomerOptions()
                {
                    CustomerId = 18,

                },db)
                .Include(c => c.Orders)
                .SingleOrDefault();

                db.Dispose();
            }
        }

    }
}
