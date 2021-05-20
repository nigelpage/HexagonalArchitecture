using System;
namespace CustomerDomain
{
    public interface ICustomerEvents
    {
        void CustomerAdded(Customer customer);
        void CustomerDeleted(Customer customer);
        void CustomerUpdated(Customer customer);
    }
}
