using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spending_Web.Models;

namespace Spending_Web.Repository
{
    public interface ITransactionRevenueRepository
    {
        List<TransactionRevenue> GetTransactionRevenues(Account account, DateTime DTFrom, DateTime DTTo);
        void InsertTransactionRevenue(TransactionRevenue transaction);

        void DeleteTransactionRevenue(int idTransaction);

        void UpdateTransactionRevenue(TransactionRevenue transaction);
    }
}
