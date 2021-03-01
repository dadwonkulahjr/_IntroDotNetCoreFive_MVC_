using System.Collections.Generic;
using System.Linq;
using DotNetCoreFive_MVC_Project.HelperResource;

namespace DotNetCoreFive_MVC_Project.Models
{
    public class CustomerImplementation : ICustomerRepository
    {
        private List<Customer> _customers;
        public CustomerImplementation()
        {
            _customers = new List<Customer>()
            {
               new Customer(){ID = 101, Name = "Tim", Email = "tim@gmail.com", Agent = Agent.Prince},
               new Customer(){ID = 102, Name = "Sara", Email = "sara@outlook.com", Agent = Agent.John},
               new Customer(){ID = 103, Name = "Mike", Email  = "mike@yahoo.com", Agent = Agent.Dorris},
               new Customer(){ID = 104, Name = "Princess", Email = "princess@hotmail.com", Agent = Agent.Alex}
            };
        }
        public Customer Create(Customer customer)
        {
            if (_customers.Any())
            {
                customer.ID = _customers.Max((c) => c.ID) + 1;
                _customers.Add(customer);
            }
            else
            {
                customer.ID = 1;
                _customers.Add(customer);
            }


            return customer;
        }
        public Customer Delete(int id)
        {
            Customer customer = _customers.FirstOrDefault((c) => c.ID == id);
            if (customer != null)
            {
                _customers.Remove(customer);
                return customer;
            }

            return null;
        }
        public Customer GetCustomer(int id)
        {
            return _customers.FirstOrDefault(x => x.ID == id);
        }
        public IEnumerable<Customer> GetListOfCustomers()
        {
            return _customers;
        }
        public Customer Update(Customer customer)
        {
            Customer cus = _customers.FirstOrDefault((c) => c.ID == customer.ID);
            if (cus != null)
            {
                cus.Name = customer.Name;
                cus.Email = customer.Email;
                cus.Agent = customer.Agent;
                return cus;
            }

            return null;
        }
    }
}
