using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCRMConsole
{
    class Order
    {
        public int OrderId { get; set; } 
        public string DeliveryAddress { get;  set; }
        public Decimal TotalAmmount { get; set; }
        public DateTimeOffset Created { get; set; }
        //public List<Product> Products { get; set; }

        public Order()
        {
            Created = DateTimeOffset.Now;
        }

        //public void CalculateAmmount()
        //{
        //    decimal totalvalue = 0;

        //    foreach (var product in Products)
        //    {
        //        totalvalue += product.Price;
        //    }

        //    TotalAmmount = totalvalue;
        //}


    }
}
