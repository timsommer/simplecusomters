using System.Collections.Generic;
using System;

namespace customers
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);

        IEnumerable<Customer> GetAll();

        void Update(Customer customer);

        void Add(Customer customer);

        void Delete(Guid id);
    }

}