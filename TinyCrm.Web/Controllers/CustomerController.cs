using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TinyCrmDbContext _dbContext;
        private ICustomerService _customerService;

        public CustomerController()
        {
            _dbContext = new TinyCrmDbContext();
            _customerService = new CustomerService(_dbContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAll();

            return Json(customers);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var customer = _customerService.SearchCustomerById(id);

            if (customer == null)
            {
                return BadRequest();
            }

            return Json(customer);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var customer = _customerService.SearchCustomerById(id);

            if (customer == null)
            {
                return BadRequest();
            }

            _dbContext.Remove(customer);

            _dbContext.SaveChanges();

            return Json(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerOptions options)
        {
            if (options == null)
            {
                return BadRequest();
            }

            var customer = _customerService.CreateCustomer(options);

            _dbContext.Add(customer);

            _dbContext.SaveChanges();

            return Json(customer);
        }

        [HttpPatch]
        public IActionResult Update([FromBody] CustomerOptions options)
        {
            var customer = _customerService.SearchCustomerById(options.CustomerId);

            if (customer == null)
            {
                return BadRequest();
            }

            //var customer = _customerService.SearchCustomerById(id);

            //if (customer == null)
            //{
            //    return BadRequest();
            //}

            _customerService.UpdateCustomer(options);

            _dbContext.SaveChanges();


            return Json(customer);
        }

        [HttpPost]
        public IActionResult SearchCustomers(CustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var customerList = _customerService
                .SearchCustomers(options)
                .ToList();

            if (customerList == null)
            {
                return NotFound();
            }

            return Json(customerList);
        }
    }
}
