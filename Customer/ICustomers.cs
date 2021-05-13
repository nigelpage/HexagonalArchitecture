using System;
namespace CustomerDomain
{
    public interface ICustomers
    {

        Customer Find(string FirstName, string LastName);
        void Add(Customer customer);
        void Delete(Customer customer);
        void Update(Customer customer);

        event EventHandler CustomerAdded;
        event EventHandler CustomerDeleted;
        event EventHandler CustomerUpdated;
    }
}
