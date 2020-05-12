using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    class OrderService : IOrderService
    {
        private readonly TinyCrmDbContext _context;
        private readonly ICustomerService _customerService;
        private readonly IProductService  _productService;

        public OrderService(TinyCrmDbContext context, ICustomerService customerService, IProductService productService)
        {
            _context = context;
            _customerService = customerService;
            _productService = productService;
        }

        public Order CreateOrder(OrderOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var order = new Order()
            {
                DeliveryAddress = options.DeliveryAddress,
                Created = DateTime.Now
            };


            foreach (var productid in options.ProductIds)
            {
                var product = _productService.SearchById(productid);

                if(product != null)
                {
                    order.OrderProducts.Add(new OrderProduct()
                    {
                        Product = product,
                        ProductId = product.ProductId
                    });
                    order.TotalAmmount += product.Price;
                }
            }

            var findCustomer = _customerService.SearchCustomerById(options.CustomerId);

            if (findCustomer == null)
            {
                return null;
            }

            findCustomer.Orders.Add(order);

            _context.Add(order);

            if (_context.SaveChanges() > 0)
            {
                return order;
            }

            return null;
        }
        public IQueryable<Order> SearchOrders(OrderOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = _context
                .Set<Order>()
                .Where(o => o.CustomerId == options.CustomerId)
                .Include(s=>s.OrderProducts)
                .AsQueryable();

            query = query.Take(500);

            return query;
        }
        public void UpdateOrder(OrderOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException();
            }

            var existingOrder = SearchOrders
            (
               new OrderOptions()
               {
                   OrderId = options.OrderId
               }

            ).SingleOrDefault();

            if (existingOrder == null)
            {
                throw new ArgumentNullException();
            }

            var existingCustomer = _customerService.SearchCustomers(
                new CustomerOptions()
                {
                    CustomerId = options.CustomerId 
                }
                ).SingleOrDefault();


            existingOrder.CustomerId = existingCustomer.Id;
            existingOrder.DeliveryAddress = options.DeliveryAddress;

            _context.SaveChanges();
        }
    }
}
