using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCRMConsole
{
    public class ProductOptions
    {
        public int ProductId { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public List<string> Categories { get; set; }
    }
}
