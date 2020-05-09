using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCRMConsole
{
    public interface ICustomerService
    {
        Customer CreateCustomer(CustomerOptions options);

        public void UpdateCustomer(CustomerOptions options);

        IQueryable<Customer> SearchCustomers(CustomerOptions options);

        public Customer SearchCustomerById(int id);


    }
}
