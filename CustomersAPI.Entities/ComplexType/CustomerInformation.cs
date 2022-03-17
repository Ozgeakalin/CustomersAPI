using CustomersAPI.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersAPI.Entities.ComplexType
{
    public class CustomerInformation
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public Int64 CustomerPhone { get; set; }
        public decimal CustomerBudget { get; set; }
        public decimal CustomerDebt { get; set; }
        public bool? GiveCredit { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}

