﻿using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Services.Options
{
    public class ProductOptions
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
        public ProductCategory Category { get; set; }
    }
}
