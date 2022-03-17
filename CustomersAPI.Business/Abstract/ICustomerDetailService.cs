using CustomersAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersAPI.Business.Abstract
{
    public interface ICustomerDetailService
    {
        List<CustomerDetail> GetAll();
        List<CustomerDetail> GetAllByCustomerId(Guid customerId);
        CustomerDetail GetById(int id);
        CustomerDetail GetLastDetailByCustomerId(Guid customerId);
        CustomerDetail Add(CustomerDetail customerDetail);
        CustomerDetail Update(CustomerDetail customerDetail);
        void Delete(Guid customerId);
        void Delete(int id);

        
    }
}
