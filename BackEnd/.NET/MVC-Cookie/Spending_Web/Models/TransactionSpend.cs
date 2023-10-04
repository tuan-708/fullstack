using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spending_Web.Models
{
    public class TransactionSpend
    {
        public TransactionSpend() { }

        public int Id { get; set; }

        public DateTime DateSpend { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public string CategorySpend { get; set; }

        public int IdAccount { get; set; }
    }
}
