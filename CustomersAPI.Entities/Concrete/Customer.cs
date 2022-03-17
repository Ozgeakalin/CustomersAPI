using CustomersAPI.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersAPI.Entities.Concrete
{
    public class Customer : IEntity
    {
        //private Guid _customerId;
        //public Guid CustomerId
        //{
        //    get {
        //        if (_customerId.ToString().Contains("000"))
        //        {
        //            _customerId = Guid.NewGuid();
        //        }
        //        return _customerId; }
        //    set { _customerId = value; }
        //}
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public Int64 CustomerPhone { get; set; }
    }
}
