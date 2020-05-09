using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCRMConsole
{
    public interface IOrderService
    {
        public Order CreateOrder(OrderOptions options);
        public void UpdateOrder(OrderOptions options);
        public IQueryable<Order> SearchOrders(OrderOptions options);
    }
}
