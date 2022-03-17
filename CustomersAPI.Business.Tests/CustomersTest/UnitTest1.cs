using CustomerAPI.DataAccess.Abstract;
using CustomerAPI.DataAccess.Concrete.EntityFramework;
using CustomersAPI.Business.Concrete;
using CustomersAPI.Entities.ComplexType;
using CustomersAPI.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CustomersAPI.Business.Tests.CustomersTest
{
    [TestClass]
    public class UnitTest1
    {
        CustomerManager _customerManager;
        [TestInitialize]
        public void TestInitialize()
        {
            _customerManager = new CustomerManager(new EfCustomerDal());

        }
        [TestMethod]
        public void CustomerAdd()

        {
            int beklenen = _customerManager.GetAll().Count; ;


            _customerManager.Add(new Customer
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "özge",
                CustomerLastName = "Akalın",
                CustomerPhone = 52455457
            }) ;

            int sonuc = _customerManager.GetAll().Count;

            Assert.AreEqual(beklenen+1, sonuc);

        }
        [TestMethod]
        public void CustomerDelete()

        {
            int beklenen = _customerManager.GetAll().Count; ;


            _customerManager.Delete(new Customer
            {
                CustomerId = Guid.Parse("b6733d40-6138-4166-9cf7-17f8312197ae"),
                CustomerName = "özge",
                CustomerLastName = "Akalın",
                CustomerPhone = 52455457
            });

            int sonuc = _customerManager.GetAll().Count;

            Assert.AreEqual(beklenen-1, sonuc);

        }
        [TestMethod]
        public void CustomerUpdate()
        {
            Customer customer = _customerManager.GetCustomerById(Guid.Parse("7b579764-88e8-4392-bcc4-883e8a63b658"));

            _customerManager.Update(new Customer
            {
                CustomerId = Guid.Parse( "7b579764-88e8-4392-bcc4-883e8a63b658"),
                CustomerName = "Sema",
                CustomerLastName = "Akalın",
                CustomerPhone = 2
            });


            Customer newCustomer = _customerManager.GetCustomerById(Guid.Parse("7b579764-88e8-4392-bcc4-883e8a63b658"));

            Assert.AreNotEqual(customer, newCustomer);

        }

        [TestMethod]
        public void CustomerGetAll()
        {
  
            List<Customer> customerList = _customerManager.GetAll();
            int beklenen = 4;
            int sonuc = customerList.Count;

            Assert.AreEqual(beklenen, sonuc);

        }

        [TestMethod]
        public void GetAllInformation()
        {

            List<CustomerInformation> customerList = _customerManager.GetAllInformation();
            int beklenen = 12;
            int sonuc = customerList.Count;

            Assert.AreEqual(beklenen, sonuc);

        }


        //[TestMethod]
        //public void GetAllInformationWithParameter()
        //{

        //    List<CustomerInformation> customerList = _customerManager.GetAllInformation(new CustomerInformation { CustomerName="özge",CustomerId=Guid.Parse("d380acea-2634-4651-8ec2-e34c3d14aa49") });
        //    int beklenen = 1;
        //    int sonuc = customerList.Count;

        //    Assert.AreEqual(beklenen, sonuc);

        //}
    }
}
