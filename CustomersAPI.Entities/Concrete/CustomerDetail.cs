using CustomersAPI.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersAPI.Entities.Concrete
{
    public class CustomerDetail: IEntity
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal CustomerBudget { get; set; }
        public decimal CustomerDebt { get; set; }
        public bool GiveCredit { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
