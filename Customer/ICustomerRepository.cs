using System;
namespace CustomerDomain
{
    public interface ICustomerRepository
    {
        Customer FindByName(string firstName, string lastName);
        Customer FindById(int id);
        int Add(Customer customer);
        void Delete(Customer customer);
        void Update(int id, Customer customer);
    }
}
