using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCRMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TinyCrmDbContext())
            {
                ICustomerService customerServvice = new CustomerService(context);

                var results = customerServvice.SearchCustomers(
                    new CustomerOptions()
                    {
                        CustomerId = 3
                    }).SingleOrDefault();
            }
        }
        

    }
}
