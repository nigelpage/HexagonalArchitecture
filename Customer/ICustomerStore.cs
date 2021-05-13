using System;
namespace CustomerDomain
{
    public interface ICustomerStore
    {
        Customer Find(string firstName, string lastName);
        void Add(Customer customer);
        void Delete(Customer customer);
        void Update(Customer customer);
    }
}
