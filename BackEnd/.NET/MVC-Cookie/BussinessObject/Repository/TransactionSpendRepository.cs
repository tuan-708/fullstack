using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.BusinessObject;
using BussinessObject.DataAccess;

namespace BussinessObject.Repository
{
    public class TransactionSpendRepository : ITransactionSpendRepository
    {
        public List<TransactionSpend> GetTransactionSpend(Account account, DateTime DTFrom, DateTime DTTo)
        {
            return TransactionSpendDAO.Intance.GetListTransactionSpendAccount(account, DTFrom, DTTo);
        }

        public void InsertTransactionSpend(TransactionSpend transaction)
        {
            TransactionSpendDAO.Intance.InsertStransactionSpend(transaction);
        }

        public void DeleteTransactionSpend(int idTransaction)
        {
            TransactionSpendDAO.Intance.DeleteTransactionSpend(idTransaction);
        }

        public void UpdateTransactionSpend(TransactionSpend transaction)
        {
            TransactionSpendDAO.Intance.UpdateTransactionSpend(transaction);
        }
    }
}
