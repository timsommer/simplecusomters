using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private static ConcurrentDictionary<Guid, Customer> _Customers = new ConcurrentDictionary<Guid, Customer>();

        public CustomerRepository()
        {
            Add(new Customer
            {
                FirstName = "Tim",
                LastName = "Sommer",
            });
        }

        public void Add(Customer customer)
        {
            _Customers[customer.Id] = customer;
        }

        public void Delete(Guid id)
        {
            Customer _customer;
            _Customers.TryRemove(id, out _customer);

            if (_customer == null)
            {
                throw new Exception("failed to remove Customer");
            }
        }

        public Customer Get(Guid id)
        {
            Customer _customer;
            _Customers.TryGetValue(id, out _customer);

            return _customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _Customers.Values;
        }

        public void Update(Customer customer)
        {
            _Customers[customer.Id] = customer;
        }
    }
}