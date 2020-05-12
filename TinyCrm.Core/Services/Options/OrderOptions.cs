using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Services.Options
{
    public class OrderOptions
    {
        public int CustomerId { get; set; }
        public List<string> ProductIds { get; set; }
        public string DeliveryAddress { get; set; }
        public int OrderId { get; set; }
        public OrderOptions()
        {
            ProductIds = new List<string>();
        }
    }
}
