using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCRMConsole.Models
{
    public class OrderProduct
    {
        public int OrderProductID { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
