using BussinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Repository
{
    public interface ITransactionSpendRepository
    {
        List<TransactionSpend> GetTransactionSpend(Account account, DateTime DTFrom, DateTime DTTo);

        void InsertTransactionSpend(TransactionSpend transaction);

        void DeleteTransactionSpend(int idTransaction);

        void UpdateTransactionSpend(TransactionSpend transaction);
    }
}
