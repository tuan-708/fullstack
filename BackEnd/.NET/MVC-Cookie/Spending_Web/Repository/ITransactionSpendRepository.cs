using Spending_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spending_Web.Repository
{
    public interface ITransactionSpendRepository
    {
        List<TransactionSpend> GetTransactionSpends(Account account, DateTime DTFrom, DateTime DTTo);

        void InsertTransactionSpend(TransactionSpend transaction);

        void DeleteTransactionSpend(int idTransaction);

        void UpdateTransactionSpend(TransactionSpend transaction);
    }
}
