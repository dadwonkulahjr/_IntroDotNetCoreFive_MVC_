using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DotNetCoreFive_MVC_Project.Models
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger<SQLCustomerRepository> _logger;

        public SQLCustomerRepository(ApplicationDbContext applicationDbContext,
            ILogger<SQLCustomerRepository> logger)
        {
            _appDbContext = applicationDbContext;
            _logger = logger;
        }
        public Customer Create(Customer customer)
        {
            var result = _appDbContext.Customers.Add(customer);
            _appDbContext.SaveChanges();
            return result.Entity;
        }
        public Customer Delete(int id)
        {
            var foundCustomer = _appDbContext.Customers.Find(id);
            if (foundCustomer != null)
            {
                _appDbContext.Customers.Remove(foundCustomer);
                _appDbContext.SaveChanges();
                return foundCustomer;
            }
            return null;
        }
        public Customer GetCustomer(int id)
        {

            _logger.LogTrace("Log Trace");
            _logger.LogDebug("Log Debug");
            _logger.LogInformation("Log Inforamtion");
            _logger.LogWarning("Log Warning");
            _logger.LogError("Log Error");
            _logger.LogCritical("Log Critical");
            return _appDbContext.Customers.Find(id);
        }
        public IEnumerable<Customer> GetListOfCustomers()
        {
            return _appDbContext.Customers;
        }
        public Customer Update(Customer customer)
        {
            var modifiedCustomer = _appDbContext.Attach(customer);
            modifiedCustomer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _appDbContext.SaveChanges();
            return modifiedCustomer.Entity;
        }
    }
}
