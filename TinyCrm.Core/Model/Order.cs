using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCrm.Core.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string DeliveryAddress { get;  set; }
        public Decimal TotalAmmount { get; set; }
        public DateTimeOffset Created { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }


        public Order()
        {
            Created = DateTimeOffset.Now;
            OrderProducts = new List<OrderProduct>();
        
        }
    }
}
