using CustomersAPI.Core.DataAccess;
using CustomersAPI.Entities.ComplexType;
using CustomersAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        IQueryable<CustomerInformation> GetCustomerInformations();
    }
}
