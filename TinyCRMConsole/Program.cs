using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TinyCrm.Core.Data;
using TinyCrm.Core.Services.Options;
using TinyCrm.Core.Services;

namespace TinyCRMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TinyCrmDbContext())
            {
                var customerService = new CustomerService(context);

                var newCustomer = customerService.CreateCustomer(new CustomerOptions()
                {
                    FirstName = "Avraam",
                    LastName = "Liaoutsis",
                    VatNumber = "1313-asdASD=123",
                    IsActive = true
                });


                //var newProduct = productService.Create(new
                //    ProductOptions()
                //{
                //    Name = "Mac os",
                //    Category = ProductCategory.Laptops,
                //    Price = 500,
                //    ProductId = "ASDASD1-242"
                //}
                //);

                //var productsToBuy = new List<Product>();
                //var productsIdsToBuy = new List<string>();

                //productsToBuy.Add(newProduct);
                //productsIdsToBuy.Add(newProduct.ProductId);


                //var newOrder = orderService.CreateOrder(new OrderOptions()
                //{
                //    CustomerId = newCustomer.Id,
                //    ProductIds = productsIdsToBuy
                //});

                //Console.WriteLine(newOrder);



                context.Dispose();
            }
        }


    }
}

