using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Services.Options
{
    public class SearchCustomerOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VatNumber { get; set; }
        public DateTime CreateFrom { get; set; }
        public DateTime CreatedTo { get; set; }
        public int? CustomerId { get; set; }

    }
}
