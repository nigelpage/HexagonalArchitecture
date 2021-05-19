using System;
namespace CustomerDomain
{
    public interface ICustomerNotify
    {
        void CustomerAdded(Customer customer);
        void CustomerDeleted(Customer customer);
        void CustomerUpdated(Customer customer);
    }
}
