using DotNetCoreFive_MVC_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DotNetCoreFive_MVC_Project.ExtentionsMethods
{
    public static class CompleteDatabaseSeeding
    {
        public static void SeedDb(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>((_builder) =>
            {
                _builder.HasData(GetSomeCustomersInitialData());
            });
        }
        public static IEnumerable<Customer> GetSomeCustomersInitialData()
        {
            return new List<Customer>()
            {
                new Customer(){ID = 1, Name = "Tom", Agent = HelperResource.Agent.Dorris, Email = "tom@t.com"},
                new Customer(){ID = 2, Name = "Mike", Agent = HelperResource.Agent.Prince, Email = "mike@m.com"},
                new Customer(){ID = 3, Name = "Princess", Agent = HelperResource.Agent.Alex, Email = "princess@p.com"},
                new Customer(){ID = 4, Name = "Sharon", Agent = HelperResource.Agent.John, Email = "sharon@s.com"}
            };
        }
    }
}
