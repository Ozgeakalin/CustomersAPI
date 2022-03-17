using CustomerAPI.DataAccess.Concrete.EntityFramework.Mapping;
using CustomersAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.DataAccess.Concrete.EntityFramework
{
    public class BankXContext : DbContext
    {
        public BankXContext() : base("BankX")
        {
          // Database.SetInitializer<BankXContext>(null);
        }
       public DbSet<Customer> Customers { get; set; }
       public DbSet<CustomerDetail> CustomerDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new CustomerDetailMap());
        }
    }

}
