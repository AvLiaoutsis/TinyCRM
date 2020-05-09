using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCRMConsole
{
    public class ProductOptions
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
        public List<ProductCategory> Categories { get; set; }
    }
}
