using System;
namespace CustomerDomain
{
    public interface ICustomers
    {

        Customer FindById(int id);
        Customer FindByName(string FirstName, string LastName);
        int Add(Customer customer);
        void Delete(Customer customer);
        void Update(int id, Customer customer);
    }
}
