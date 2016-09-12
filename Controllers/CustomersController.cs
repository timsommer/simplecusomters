
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace customers.Controllers
{
    [Route("api/[Controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _Repository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _Repository = customerRepository;
        }

        //GET /api/customers
        public IEnumerable<Customer> GetAll()
        {
            return _Repository.GetAll();
        }

        //GET /api/customers/{id}
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetById(Guid id)
        {
            var _customer = _Repository.Get(id);
            if (_customer == null)
            {
                return NotFound();
            }

            return new ObjectResult(_customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            _Repository.Add(customer);
            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpPost("{id}")]
        public IActionResult Update(Guid id, Customer customer)
        {

            if (customer == null || customer.Id != id)
            {
                return BadRequest();
            }

            var _customer = _Repository.Get(id);
            if (_customer == null)
            {
                return NotFound();
            }

            _Repository.Update(customer);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var todo = _Repository.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            _Repository.Delete(id);
            return new NoContentResult();
        }
    }
}

