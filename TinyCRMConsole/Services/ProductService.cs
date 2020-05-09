using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCRMConsole
{
    class ProductService : IProductService
    {
        private readonly TinyCrmDbContext _context;

        public ProductService(TinyCrmDbContext context)
        {
            _context = context;
        }

        public Product Create(ProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var product = new Product()
            {
                Name = options.Name,
                Price = options.Price,
                ProductId = options.ProductId
            };

            _context.Add(product);

            if (_context.SaveChanges() > 0)
            {
                return product;
            }

            return null;
        }
        public IQueryable<Product> Search(ProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = _context
                .Set<Product>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.Name))
            {
                query = query.Where(c => c.Name == options.Name);
            }

            if (options != null)
            {
                query = query.Where(c => c.ProductId == options.ProductId);
            }

            if (options != null)
            {
                query = query.Where(c => c.Price >= options.Price);
            }

            if (options != null)
            {
                query = query.Where(c => c.Price >= options.MinPrice && c.Price <= options.MaxPrice);
            }

            query = query.Take(500);

            return query;
        }
        public Product SearchById(string id)
        {
            var existingProduct = Search(new ProductOptions()
            {
                ProductId = id
            }).SingleOrDefault();

            if (existingProduct == null)
            {
                return null;
            }

            return existingProduct;
        }
        public void Update(ProductOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException();
            }

            var existingProduct = SearchById(options.ProductId);

            if (existingProduct == null)
            {
                throw new ArgumentNullException();
            }

            existingProduct.Name = options.Name;
            existingProduct.Price = options.Price;

            _context.SaveChanges();
        }
    }
}
