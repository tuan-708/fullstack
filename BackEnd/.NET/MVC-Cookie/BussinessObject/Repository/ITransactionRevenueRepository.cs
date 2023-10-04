using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.BusinessObject;

namespace BussinessObject.Repository
{
    public interface ITransactionRevenueRepository
    {
        List<TransactionRevenue> GetTransactionRevenue(Account account, DateTime DTFrom, DateTime DTTo);
        void InsertTransactionRevenue(TransactionRevenue transaction);

        void DeleteTransactionRevenue(int idTransaction);

        void UpdateTransactionRevenue(TransactionRevenue transaction);
    }
}
