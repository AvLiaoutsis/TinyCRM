using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCRMConsole.Models
{
    public class Order
    {
        public int OrderId { get; set; } 
        public string DeliveryAddress { get; set; }
        public Decimal TotalAmmount { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

        public Order()
        {
            OrderProducts = new List<OrderProduct>();
        }




    }
}
