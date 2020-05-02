using System;
using System.Collections.Generic;
using System.Linq;
using TinyCRMConsole.Models;
using TinyCRMConsole.Options;
using TinyCRMConsole.Services;

namespace TinyCRMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var custOpt = new CustomerOptions()
            {
                FirstName = "Avraam",
                LastName = "Liaoutsis",
                Address = "Athens",
                VatNumber = "012345678",
                Email = "av.liaoutsis@outlook.com",
                Phone = "6901230000",
                DateOfBirth = new DateTime(1995,10,14)
            };

            var custCrud = new CustomerCrud();

            var customer = custCrud.CreateCustomer(custOpt);

            Console.WriteLine("Id = " + customer.CustomerID +
                " FirstName = " + customer.FirstName);

            Customer toFind = custCrud.GetCustomerById(100);

            if(toFind != null)
            {
                Console.WriteLine("Id = " + toFind.CustomerID +
                  " FirstName = " + toFind.FirstName);
            }



        }
    }
}
