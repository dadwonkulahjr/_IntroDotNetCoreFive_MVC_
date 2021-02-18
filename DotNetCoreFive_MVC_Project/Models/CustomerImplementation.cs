
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreFive_MVC_Project.Models
{
    public class CustomerImplementation : ICustomerRepository
    {
        private List<Customer> _customers;
        public CustomerImplementation()
        {
            _customers = new List<Customer>()
            {
               new Customer(){ID = 101, Name = "Tim", Email = "tim@gmail.com", Agent = "Prince"},
               new Customer(){ID = 102, Name = "Sara", Email = "sara@outlook.com", Agent = "John"},
               new Customer(){ID = 103, Name = "Mike", Email  = "mike@yahoo.com", Agent = "Dorris"},
               new Customer(){ID = 104, Name = "Princess", Email = "princess@hotmail.com", Agent = "Alex"}
            };
        }
        public Customer GetCustomer(int id)
        {
            return _customers.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Customer> GetListOfCustomers()
        {
            return _customers;
        }
    }
}
