using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomers _customers;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ICustomers customers, ILogger<CustomersController> logger)
        {
            _customers = customers;
            _logger = logger;
        }

        [HttpGet]
        public Customer FindByName(string firstName, string lastName)
        {
            return _customers.FindByName(firstName, lastName);
        }

        [HttpGet]
        public Customer FindById(int id)
        {
            return _customers.FindById(id);
        }

        [HttpPost]
        public int Insert(string firstName, string lastName, DateTime dateOfBirth)
        {
            return _customers.Add(new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            });
        }

        [HttpPut]
        public void Update(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            _customers.Update(id, new Customer()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            });
        }

        [HttpDelete]
        public void Delete(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            _customers.Delete(new Customer()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            });
        }
    }
}
