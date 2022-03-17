using CustomerAPI.DataAccess.Abstract;
using CustomerAPI.DataAccess.Concrete.EntityFramework;
using CustomersAPI.Business.Abstract;
using CustomersAPI.Business.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersAPI.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerDal>().To<EfCustomerDal>();

            Bind<ICustomerDetailService>().To<CustomerDetailManager>().InSingletonScope();
            Bind<ICustomerDetailDal>().To<EfCustomerDetailDal>();

            Bind<DbContext>().To<BankXContext>();
        }
    }
}
