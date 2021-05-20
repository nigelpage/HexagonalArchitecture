using System;
namespace CustomerDomain
{
    /// <summary>
    /// Hexagonal architecture ensures that a class implementing a domain is independent of any classes it may be dependent upon and
    /// any classes that elect to expose its functionality. This makes it simple to test and easy to 'wire up' to a broader landscape.
    /// Whilst there is no specific mechanism that should be used to achieve this, this example utlises dependency injection.
    ///
    /// A simple class representing the customers domain
    /// N.B. In practice this would contain all the operations that can be perfomed on the collection of customers
    ///
    /// Important things to note: -
    ///
    /// 1) the repository where customers are stored is in a separate class which is dependency injected via the constructor
    /// 2) the notification/event mechanism is in a separate class which is dependency injected via the constructor
    /// 3) this class implements an interface defining the functions on offer through this domain
    ///    enabling it to be dependency injected into a class exposing it to a broader audience (e.g. via REST, gRPC, GraphQL, etc...)
    /// </summary>
    public class Customers : ICustomers
    {
        private readonly ICustomerRepository _repository;
        private readonly ICustomerEvents _events;

        public Customers(ICustomerRepository repository, ICustomerEvents notify)
        {
            _repository = repository;
            _events = notify;
        }

        public Customer FindByName(string firstName, string lastName)
        {
            return _repository.FindByName(firstName, lastName);
        }

        public Customer FindById(int id)
        {
            return _repository.FindById(id);
        }

        public int Add(Customer customer)
        {
            int id = _repository.Add(customer);
            _events.CustomerAdded(customer);
            return id;
        }

        public void Delete(Customer customer)
        {
            _repository.Delete(customer);
            _events.CustomerDeleted(customer);
        }

        public void Update(int id, Customer customer)
        {
            _repository.Update(id, customer);
            _events.CustomerUpdated(customer);
        }
    }
}
