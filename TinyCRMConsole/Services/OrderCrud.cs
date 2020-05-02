using System;
using System.Collections.Generic;
using System.Text;
using TinyCRMConsole.Models;
using TinyCRMConsole.Options;
using TinyCRMConsole.Persistence;

namespace TinyCRMConsole.Services
{
    class OrderCrud
    {
        public Order CreateOrder(OrderOptions customerOptions)
        {
            var order = new Order()
            {
                DeliveryAddress = customerOptions.DeliveryAddress,
                TotalAmmount = customerOptions.TotalAmmount,
                
            };

            using AppDbContext dbContext = new AppDbContext();

            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

            return order;
        }

        public Order GetOrderById(int id)
        {
            using AppDbContext dbContext = new AppDbContext();

            var order = dbContext.Orders.Find(id);

            return order;
        }
    }
}
