using CustomerAPI.DataAccess.Abstract;
using CustomersAPI.Core.DataAccess.EntityFramework;
using CustomersAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDetailDal :EfEntityRepositoryBase<CustomerDetail,BankXContext>, ICustomerDetailDal
    {
    }
}
