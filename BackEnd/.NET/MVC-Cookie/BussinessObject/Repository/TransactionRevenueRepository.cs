using BussinessObject.BusinessObject;
using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Repository
{
    public class TransactionRevenueRepository : ITransactionRevenueRepository
    {
        public List<TransactionRevenue> GetTransactionRevenue(Account account, DateTime DTFrom, DateTime DTTo)
        {
            return TransactionRevenueDAO.Intance.GetListTransactionRevenueAccount(account, DTFrom, DTTo);
        }

        public void InsertTransactionRevenue(TransactionRevenue transaction)
        {
            TransactionRevenueDAO.Intance.InsertStransactionRevenue(transaction);
        }

        public void DeleteTransactionRevenue(int idTransaction)
        {
            TransactionRevenueDAO.Intance.DeleteTransactionRevenue(idTransaction);
        }

        public void UpdateTransactionRevenue(TransactionRevenue transaction)
        {
            TransactionRevenueDAO.Intance.UpdateTransactionRevenue(transaction);
        }

    }
}
