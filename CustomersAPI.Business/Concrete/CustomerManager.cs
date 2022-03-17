using CustomerAPI.DataAccess.Abstract;
using CustomersAPI.Business.Abstract;
using CustomersAPI.Business.DependencyResolvers.Ninject;
using CustomersAPI.Entities.ComplexType;
using CustomersAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomersAPI.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public Customer Add(Customer customer)
        {
            return _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer GetCustomerById(Guid id)
        {
            return _customerDal.Get(x => x.CustomerId == id);
        }

        public Customer Update(Customer customer)
        {
            return _customerDal.Update(customer);
        }

        public List<CustomerInformation> GetAllInformation()
        {
            return _customerDal.GetCustomerInformations().ToList();
        }

        public List<CustomerInformation> GetAllInformation(CustomerInformation model)
        {
            var result = _customerDal.GetCustomerInformations();
            if (model.CustomerId != null)
            {
                result = result.Where(x => x.CustomerId == model.CustomerId);
            }
            if (!String.IsNullOrEmpty(model.CustomerName))
            {
                result = result.Where(x => x.CustomerName == model.CustomerName);
            }
            if (!String.IsNullOrEmpty(model.CustomerLastName))
            {
                result = result.Where(x => x.CustomerLastName == model.CustomerLastName);
            }
            if (model.GiveCredit != null)
            {
                result = result.Where(x => x.GiveCredit == model.GiveCredit);
            }
            return result.ToList();
        }
        public CustomerInformation GetCustomerWithLastDetail(Guid id)
        {
        
          
            var customer = GetCustomerById(id);
            CustomerDetailManager detailManager = new CustomerDetailManager(InstanceFactory.GetInstance<ICustomerDetailDal>());
            var detail = detailManager.GetLastDetailByCustomerId(id);
            if (detail != null && customer != null)
            {
                CustomerInformation information = new CustomerInformation
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    CustomerLastName = customer.CustomerLastName,
                    CustomerPhone = customer.CustomerPhone,
                    CustomerBudget = detail.CustomerBudget,
                    CustomerDebt = detail.CustomerDebt,
                    GiveCredit = detail.GiveCredit,
                    TransactionDate = detail.TransactionDate,
                };
                return information;
            }
            else
                return null;

        }
    }
}