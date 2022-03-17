using CustomerAPI.DataAccess.Abstract;
using CustomerAPI.DataAccess.Concrete.EntityFramework;
using CustomersAPI.Business.Abstract;
using CustomersAPI.Business.Concrete;
using CustomersAPI.Entities.ComplexType;
using CustomersAPI.Entities.Concrete;
using CustomersAPI.WebAPI.Attributes;
using CustomersAPI.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CustomersAPI.WebAPI.Controllers
{
    [ApiException]
    public class CustomerController : ApiController
    {
        private ICustomerService _customerService;
        private ICustomerDetailService _customerDetailService;
        public CustomerController(ICustomerService customerService, ICustomerDetailService customerDetailService)
        {
            _customerDetailService = customerDetailService;
            _customerService = customerService;
        }
        [HttpGet]
        [ResponseType(typeof(List<Customer>))]
        public IHttpActionResult GetAll()
        {

            ResponseModel<Customer> responseModel = new ResponseModel<Customer> { dataList = _customerService.GetAll() };
            return Ok(responseModel.dataList);
        }

        [HttpGet]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomerById(Guid id)
        {

            ResponseModel<Customer> responseModel = new ResponseModel<Customer>
            { data = _customerService.GetCustomerById(id) };
            return responseModel.data == null
                ? NotFound()
                : (IHttpActionResult)Ok(responseModel.data);
        }

        [HttpGet]
        [ResponseType(typeof(CustomerInformation))]
        public IHttpActionResult GetCustomerWithLastDetail(Guid id)
        {

            ResponseModel<CustomerInformation> responseModel = new ResponseModel<CustomerInformation>
            { data = _customerService.GetCustomerWithLastDetail(id) };
            return responseModel.data != null ? (IHttpActionResult)Ok(responseModel.data) : NotFound();



        }

        [HttpGet]
        [ResponseType(typeof(List<CustomerInformation>))]
        public IHttpActionResult GetAllCustomersInformation()
        {

            ResponseModel<CustomerInformation> responseModel = new ResponseModel<CustomerInformation> { dataList = _customerService.GetAllInformation() };
            return Ok(responseModel.dataList);
        }



        [HttpGet]
        [ResponseType(typeof(List<CustomerInformation>))]
        public IHttpActionResult GetCustomerAllInformation(CustomerInformation model)
        {

            ResponseModel<CustomerInformation> responseModel = new ResponseModel<CustomerInformation>
            { dataList = _customerService.GetAllInformation(model) };
            if (responseModel.dataList.Count != 0)
            {
                return Ok(responseModel.dataList);
            }
            else
            {
                return BadRequest("Gönderilen veri ile müsteri detay bilgisi bulunmamaktadır");
            }
        }



        [HttpPost]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult AddCustomer([FromBody] Customer model)
        {
            var createdCustomer = _customerService.Add(model);
            createdCustomer.CustomerId = Guid.NewGuid();
            return CreatedAtRoute("DefaultApi", new { id = createdCustomer.CustomerId }, createdCustomer);
        }



        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCustomer(Customer model)
        {

            if (_customerService.GetCustomerById(model.CustomerId) == null)
            {
                return NotFound();
            }
            else
            {
                _customerService.Delete(model);
                _customerDetailService.Delete(model.CustomerId);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }



        [HttpPut]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult UpdateCustomer(Customer model)
        {
            if (_customerService.GetCustomerById(model.CustomerId) == null)
            {
                return NotFound();
            }
            else
            {
                var updatedCustomer = _customerService.Update(model);
                return Ok(updatedCustomer);
            }

        }



        /******CUSTOMERDETAIL*********/

        [HttpGet]
        [ResponseType(typeof(List<CustomerDetail>))]
        public IHttpActionResult GetAllDetail()
        {
            ResponseModel<CustomerDetail> responseModel = new ResponseModel<CustomerDetail>
            { dataList = _customerDetailService.GetAll() };
            return Ok(responseModel.dataList);
        }



        [HttpGet]
        [ResponseType(typeof(CustomerDetail))]
        public IHttpActionResult GetDetailById(int id)
        {
            ResponseModel<CustomerDetail> responseModel = new ResponseModel<CustomerDetail>
            { data = _customerDetailService.GetById(id) };
            return responseModel.data == null
                ? NotFound()
                : (IHttpActionResult)Ok(responseModel.data);
        }

        [HttpGet]
        [ResponseType(typeof(List<CustomerDetail>))]
        public IHttpActionResult GetAllDetailByCustomerId(Guid id)
        {
            ResponseModel<CustomerDetail> responseModel = new ResponseModel<CustomerDetail> { dataList = _customerDetailService.GetAllByCustomerId(id) };
            return responseModel.dataList.Count > 0 ? (IHttpActionResult)Ok(responseModel.dataList) : NotFound();
        }

        [HttpPost]
        [ResponseType(typeof(CustomerDetail))]
        public IHttpActionResult AddDetail(CustomerDetail detail)
        {
            detail.TransactionDate = DateTime.Now;

            if (detail.CustomerId == null)
            {
                return BadRequest("CustomerId boş olamaz");
            }
            else
            {
                var createdDetail = _customerDetailService.Add(detail);
                return CreatedAtRoute("DefaultApi", new { id = detail.Id }, createdDetail);
            }
        }


        [HttpPut]
        [ResponseType(typeof(CustomerDetail))]
        public IHttpActionResult UpdateDetail(CustomerDetail detail)
        {
            var updatedDetail = _customerDetailService.Update(detail);
            return Ok(updatedDetail);
        }

        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteDetail(int id)
        {
            var deleted = _customerDetailService.GetById(id);
            if (_customerDetailService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                _customerDetailService.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }

        }
    }
}