using System;
namespace CustomerDomain
{
    /// <summary>
    /// A simple notification class that fires events.
    /// N.B. This could be replaced by a class that sends messages using KubeMQ, Kafka, Azure Event Hubs, Amazon SQS, etc...
    /// </summary>
    public class CustomerEvents : ICustomerEvents
    {
        public CustomerEvents()
        {
        }

        public void CustomerAdded(Customer customer)
        {
            OnCustomerAdded(customer);
        }

        public void CustomerDeleted(Customer customer)
        {
            OnCustomerDeleted(customer);
        }

        public void CustomerUpdated(Customer customer)
        {
            OnCustomerUpdated(customer);
        }

        public event EventHandler NotifyCustomerAdded;
        public event EventHandler NotifyCustomerDeleted;
        public event EventHandler NotifyCustomerUpdated;

        protected virtual void OnCustomerAdded(Customer customer)
        {
            NotifyCustomerAdded?.Invoke(this, new CustomerEventArgs(customer));
        }

        protected virtual void OnCustomerDeleted(Customer customer)
        {
            NotifyCustomerDeleted?.Invoke(this, new CustomerEventArgs(customer));
        }

        protected virtual void OnCustomerUpdated(Customer customer)
        {
            NotifyCustomerUpdated?.Invoke(this, new CustomerEventArgs(customer));
        }
    }

    public class CustomerEventArgs : EventArgs
    {
        private readonly Customer _customer;

        public CustomerEventArgs(Customer customer)
        {
            _customer = customer;
        }

        public Customer Customer { get { return _customer; } }
    }
}
