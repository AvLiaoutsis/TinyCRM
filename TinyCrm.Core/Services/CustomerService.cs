using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly TinyCrmDbContext _context;

        public CustomerService(TinyCrmDbContext context)
        {
            _context = context;
        }

        public Customer CreateCustomer(CustomerOptions options)
        {
            if(options == null)
            {
                return null;
            }

            var customer = new Customer()
            {
                LastName = options.LastName,
                FirstName = options.FirstName,
                VatNumber = options.VatNumber
            };

            _context.Add(customer);

            if(_context.SaveChanges() > 0)
            {
                return customer;
            }

            return null;
        }

        public IQueryable<Customer> SearchCustomers(CustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = _context
                .Set<Customer>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.FirstName))
            {
                query = query.Where(c => c.FirstName == options.FirstName);
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                query = query.Where(c => c.VatNumber == options.VatNumber);
            }

            if (options != null)
            {
                query = query.Where(c => c.Id == options.CustomerId);
            }

            if (options.CreateFrom != null)
            {
                query = query.Where(c => c.Created >= options.CreateFrom);
            }

            query = query.Take(500);

            return query;
        }

        public Customer SearchCustomerById(int id)
        {
            var existingCustomer = SearchCustomers(new CustomerOptions()
            {
                CustomerId = id
            }).SingleOrDefault();

            if (existingCustomer == null)
            {
                return null;
            }

            return existingCustomer;
        }
        public void UpdateCustomer(CustomerOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException();
            }

            var existingCustomer = SearchCustomers
            (
                new CustomerOptions()
                {
                    CustomerId = options.CustomerId
                }
            ).SingleOrDefault();

            if (existingCustomer == null)
            {
                throw new ArgumentNullException();
            }

            existingCustomer.IsActive = options.IsActive;
            existingCustomer.FirstName = options.FirstName;
            existingCustomer.LastName = options.LastName;
            existingCustomer.VatNumber = options.VatNumber;


            _context.SaveChanges();
        }
    }
}
