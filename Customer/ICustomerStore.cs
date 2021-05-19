using System;
namespace CustomerDomain
{
    public interface ICustomerStore
    {
        Customer FindByName(string firstName, string lastName);
        Customer FindById(int id);
        int Add(Customer customer);
        void Delete(Customer customer);
        void Update(int id, Customer customer);
    }
}
