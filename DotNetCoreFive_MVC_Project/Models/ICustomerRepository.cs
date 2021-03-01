using System.Collections.Generic;

namespace DotNetCoreFive_MVC_Project.Models
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetListOfCustomers();
        Customer Create(Customer customer);
        Customer Update(Customer customer);
        Customer Delete(int id);
    }
}
