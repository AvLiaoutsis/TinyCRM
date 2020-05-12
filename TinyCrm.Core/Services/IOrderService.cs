using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface IOrderService
    {
        public Order CreateOrder(OrderOptions options);

        public void UpdateOrder(OrderOptions options);

        public IQueryable<Order> SearchOrders(OrderOptions options);

    }
}
