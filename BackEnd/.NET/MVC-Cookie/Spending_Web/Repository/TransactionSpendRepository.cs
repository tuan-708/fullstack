using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spending_Web.Models;
using Spending_Web.DataAccess;

namespace Spending_Web.Repository
{
    public class TransactionSpendRepository : ITransactionSpendRepository
    {
        //get all transaction spend account
        public List<TransactionSpend> GetTransactionSpends(Account account, DateTime DTFrom, DateTime DTTo)
        {
            return TransactionSpendDAO.Intance.GetListTransactionSpendAccount(account, DTFrom, DTTo);
        }

        public void InsertTransactionSpend(TransactionSpend transaction)
        {
            TransactionSpendDAO.Intance.InsertStransactionSpend(transaction);
        }

        public void DeleteTransactionSpend(int idTransaction)
        {
            TransactionSpendDAO.Intance.DeleteStransactionSpend(idTransaction);
        }

        public void UpdateTransactionSpend(TransactionSpend transaction)
        {
            TransactionSpendDAO.Intance.UpdateTransactionSpend(transaction);
        }
    }
}
