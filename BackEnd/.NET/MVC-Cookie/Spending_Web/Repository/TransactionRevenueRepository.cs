using Spending_Web.Models;
using Spending_Web.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spending_Web.Repository
{
    public class TransactionRevenueRepository : ITransactionRevenueRepository
    {
        //get all transaction revenue account
        public List<TransactionRevenue> GetTransactionRevenues(Account account, DateTime DTFrom, DateTime DTTo)
        {
            return TransactionRevenueDAO.Intance.GetListTransactionRevenueAccount(account, DTFrom, DTTo);
        }

        public void InsertTransactionRevenue(TransactionRevenue transaction)
        {
            TransactionRevenueDAO.Intance.InsertStransactionRevenue(transaction);
        }

        public void DeleteTransactionRevenue(int idTransaction)
        {
            TransactionRevenueDAO.Intance.DeleteStransactionRevenue(idTransaction);
        }

        public void UpdateTransactionRevenue(TransactionRevenue transaction)
        {
            TransactionRevenueDAO.Intance.UpdateTransactionRevenue(transaction);
        }

    }
}
