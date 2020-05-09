using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCRMConsole
{
    public class CustomerOptions
    {
        public string VatNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset CreateFrom { get; set; }
        public DateTimeOffset CreateTo { get; set; }
        public bool IsActive { get; set; }
    }
}
