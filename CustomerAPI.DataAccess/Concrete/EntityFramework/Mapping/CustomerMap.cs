using CustomersAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.DataAccess.Concrete.EntityFramework.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable(@"Customers", @"dbo");
            HasKey(x => x.CustomerId);

            Property(x => x.CustomerId).HasColumnName("CustomerId");
            Property(x => x.CustomerName).HasColumnName("CustomerName");
            Property(x => x.CustomerLastName).HasColumnName("CustomerLastName");
            Property(x => x.CustomerPhone).HasColumnName("CustomerPhone");
        }
    }
}
