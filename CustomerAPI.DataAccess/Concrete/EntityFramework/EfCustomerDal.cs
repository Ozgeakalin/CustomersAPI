using CustomerAPI.DataAccess.Abstract;
using CustomersAPI.Core.DataAccess.EntityFramework;
using CustomersAPI.Entities.ComplexType;
using CustomersAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, BankXContext>, ICustomerDal
    {
        public IQueryable<CustomerInformation> GetCustomerInformations()
        {
            BankXContext context = new BankXContext();
                           

                var result = (from c in context.Customers
                              join cd in context.CustomerDetails
                              on c.CustomerId equals cd.CustomerId
                              select new CustomerInformation{ 
                                  CustomerId = c.CustomerId,
                                  CustomerName = c.CustomerName,
                                  CustomerLastName = c.CustomerLastName,
                                  CustomerPhone = c.CustomerPhone,
                                  CustomerBudget = cd.CustomerBudget,
                                  CustomerDebt = cd.CustomerDebt,
                                  GiveCredit = cd.GiveCredit,
                                  TransactionDate=cd.TransactionDate
                              });
                return result;

            context.Dispose();
        }
      
    }
}
