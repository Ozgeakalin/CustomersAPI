using CustomerAPI.DataAccess.Abstract;
using CustomersAPI.Business.Abstract;
using CustomersAPI.Entities.ComplexType;
using CustomersAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersAPI.Business.Concrete
{
    public class CustomerDetailManager : ICustomerDetailService
    {
        private ICustomerDetailDal _customerDetailDal;
        public CustomerDetailManager(ICustomerDetailDal customerDetailDal)
        {
            _customerDetailDal = customerDetailDal;
        }

        public CustomerDetail Add(CustomerDetail customerDetail)
        {
            return _customerDetailDal.Add(customerDetail);
        }

        public void Delete(Guid customerId)
        {
            if (GetAllByCustomerId(customerId)!=null)
            {
                foreach (CustomerDetail item in GetAllByCustomerId(customerId))
                {
                    _customerDetailDal.Delete(item);
                }
            }
           
        }

        public void Delete(int id)
        {
            _customerDetailDal.Delete(GetById(id));
        }

        public List<CustomerDetail> GetAll()
        {
            return _customerDetailDal.GetAll();
        }

        public List<CustomerDetail> GetAllByCustomerId(Guid customerId)
        {
            return _customerDetailDal.GetAll(x => x.CustomerId == customerId);
        }

        public CustomerDetail GetLastDetailByCustomerId(Guid customerId)
        {
            return _customerDetailDal.GetAll(x => x.CustomerId == customerId)
                                     .OrderByDescending(x => x.TransactionDate.Date)
                                     .ThenByDescending(x => x.TransactionDate.TimeOfDay)
                                     .FirstOrDefault();
        }

        public CustomerDetail GetById(int id)
        {
          return  _customerDetailDal.Get(x => x.Id == id);
        }

        public CustomerDetail Update(CustomerDetail customerDetail)
        {
            return _customerDetailDal.Update(customerDetail);
        }
    }
}
