using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCRMConsole
{
    public class DummyCustomerService 
    {
        public Customer CreateCustomer(CustomerOptions options)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> SearchCustomers(SearchCustomerOptions options)
        {
            var customer = new Customer()
            {
                FirstName = "Dummy",
                LastName = "Customer",
                Id = 3
            };

            var list = new List<Customer>();

            return list.AsQueryable();
        }
    }
}
