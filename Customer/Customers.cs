using System;
namespace CustomerDomain
{
    public class Customers : ICustomers
    {
        private readonly ICustomerStore _store;

        public Customers(ICustomerStore store)
        {
            _store = store;
        }

        public event EventHandler CustomerAdded;
        public event EventHandler CustomerDeleted;
        public event EventHandler CustomerUpdated;

        public Customer Find(string firstName, string lastName)
        {
            return _store.Find(firstName, lastName);
        }

        public void Add(Customer customer)
        {
            _store.Add(customer);

            OnCustomerAdded(customer);
        }

        public void Delete(Customer customer)
        {
            _store.Delete(customer);

            OnCustomerDeleted(customer);
        }

        public void Update(Customer customer)
        {
            _store.Update(customer);

            OnCustomerUpdated(customer);
        }

        protected virtual void OnCustomerAdded(Customer customer)
        {
            CustomerAdded?.Invoke(this, new CustomerAddedEventArgs(customer));
        }

        protected virtual void OnCustomerDeleted(Customer customer)
        {
            CustomerDeleted?.Invoke(this, new CustomerDeletedEventArgs(customer));
        }

        protected virtual void OnCustomerUpdated(Customer customer)
        {
            CustomerUpdated?.Invoke(this, new CustomerUpdatedEventArgs(customer));
        }
    }

    public abstract class CustomersEventArgs : EventArgs
    {
        private readonly Customer _customer;

        public CustomersEventArgs(Customer customer)
        {
            _customer = customer;
        }

        public Customer Customer { get { return _customer; } }
    }

    public class CustomerAddedEventArgs : CustomersEventArgs
    {
        public CustomerAddedEventArgs(Customer customer)
            : base(customer)
        { }
    }

    public class CustomerDeletedEventArgs : CustomersEventArgs
    {
        public CustomerDeletedEventArgs(Customer customer)
            : base(customer)
        { }
    }

    public class CustomerUpdatedEventArgs : CustomersEventArgs
    {
        public CustomerUpdatedEventArgs(Customer customer)
            : base(customer)
        { }
    }

}
