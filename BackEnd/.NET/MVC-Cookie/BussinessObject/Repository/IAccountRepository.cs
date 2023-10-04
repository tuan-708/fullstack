using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.BusinessObject;

namespace BussinessObject.Repository
{
    public interface IAccountRepository
    {
        List<Account> getAccounts();
        Account GetAccountByAccountName(string accountName);
        void InsertAccount(Account account);
        void DeleteAccount(int Id);
        void UpdateAccount(Account account);
        Account AuthenAccount(Account account);

    }
}
