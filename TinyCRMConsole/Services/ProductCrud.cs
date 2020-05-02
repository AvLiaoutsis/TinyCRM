using System;
using System.Collections.Generic;
using System.Text;
using TinyCRMConsole.Models;
using TinyCRMConsole.Options;
using TinyCRMConsole.Persistence;

namespace TinyCRMConsole.Services
{
    class ProductCrud
    {
        public Product CreateProduct(ProductOptions productOptions)
        {
            var product = new Product()
            {
                Name = productOptions.Name,
                Description = productOptions.Description,
                Price = productOptions.Price
            };

            using AppDbContext dbContext = new AppDbContext();

            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return product;
        }

        public Product GetProductById(int id)
        {
            using AppDbContext dbContext = new AppDbContext();

            var product = dbContext.Products.Find(id);

            return product;
        }
    }
}
