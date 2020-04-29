using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCRMConsole
{
    class Order
    {
        public int OrderId { get; set; } 
        public string DeliveryAddress { get; set; }
        public Decimal TotalAmmount { get; set; }
    }
}
