using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface ICustomerService
    {
        Customer CreateCustomer(CustomerOptions options);

        public void UpdateCustomer(CustomerOptions options);

        IQueryable<Customer> SearchCustomers(CustomerOptions options);

        public Customer SearchCustomerById(int id);


    }
}
