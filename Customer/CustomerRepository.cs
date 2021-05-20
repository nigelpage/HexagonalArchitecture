using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerDomain
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers;
        private int _maxCustomerId;

        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }

        public Customer FindByName(string firstName, string lastName)
        {
            return _customers.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
        }

        public Customer FindById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        public int Add(Customer customer)
        {
            if (!_customers.Contains(customer))
            {
                _customers.Add(customer);
                customer.Id = _maxCustomerId++;
                return customer.Id;
            }
            else
                throw new Exception("Customer already in the store!");
        }

        public void Delete(Customer customer)
        {
            if (_customers.Contains(customer))
                _customers.Remove(customer);
            else
                throw new Exception("Customer not in the store!");
        }

        public void Update(int id, Customer customer)
        {
            Customer storedCustomer = FindById(id);
            if (storedCustomer != null)
            {
                storedCustomer.LastName = customer.LastName;
                storedCustomer.FirstName = customer.FirstName;
                storedCustomer.DateOfBirth = customer.DateOfBirth;
            }
            else
                throw new Exception("Customer not found!");

        }
    }
}

