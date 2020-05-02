using System;
using System.Collections.Generic;
using System.Text;
using TinyCRMConsole.Models;
using TinyCRMConsole.Options;
using TinyCRMConsole.Persistence;

namespace TinyCRMConsole.Services
{
    public class CustomerCrud
    {
        public Customer CreateCustomer(CustomerOptions customerOptions)
        {
            var customer = new Customer()
            {
                FirstName = customerOptions.FirstName,
                LastName = customerOptions.LastName,
                Address = customerOptions.Address,
                Created = DateTime.Now,
                DateOfBirth = customerOptions.DateOfBirth,
                Email = customerOptions.Email,
                IsActive = true,
                Phone = customerOptions.Phone,
                VatNumber = customerOptions.VatNumber,
                TotalGross = 0m
            };

            using AppDbContext dbContext = new AppDbContext();

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            return customer;
        }

        public Customer GetCustomerById(int id)
        {
            using AppDbContext dbContext = new AppDbContext();

            var customer = dbContext.Customers.Find(id);

            return customer;
        }
    }
}
