using CustomersAPI.Entities.ComplexType;
using CustomersAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomersAPI.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetCustomerById(Guid id);
        Customer Add(Customer customer);
        Customer Update(Customer customer);
        void Delete(Customer customer);
        List<CustomerInformation> GetAllInformation();
        List<CustomerInformation> GetAllInformation(CustomerInformation model);
        CustomerInformation GetCustomerWithLastDetail(Guid id);

    }
}
