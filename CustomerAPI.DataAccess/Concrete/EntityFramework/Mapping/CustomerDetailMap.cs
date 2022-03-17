using CustomersAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.DataAccess.Concrete.EntityFramework.Mapping
{
    public class CustomerDetailMap : EntityTypeConfiguration<CustomerDetail>
    {
        public CustomerDetailMap()
        {
            ToTable("CustomerDetails", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.CustomerId).HasColumnName("CustomerId");
            Property(x=>x.Id).HasColumnName("Id");
            Property(x => x.CustomerBudget).HasColumnName("CustomerBudget");
            Property(x => x.CustomerDebt).HasColumnName("CustomerDebt");
            Property(x => x.GiveCredit).HasColumnName("GiveCredit");
            Property(x => x.TransactionDate).HasColumnName("TransactionDate");

           
        }
    }
}
