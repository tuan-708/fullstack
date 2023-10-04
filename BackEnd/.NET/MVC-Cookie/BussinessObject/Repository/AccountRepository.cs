using BussinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.DataAccess;

namespace BussinessObject.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account AuthenAccount(Account account)
        {
            return AccountDAO.Intance.AuthenAccount(account);
        }

        public void DeleteAccount(int Id)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountByAccountName(string accountName)
        {
            return AccountDAO.Intance.GetAccountByAccountName(accountName);
        }

        public List<Account> getAccounts()
        {
            return AccountDAO.Intance.GetAccounts();
        }

        public void InsertAccount(Account account)
        {
            AccountDAO.Intance.InsertAccount(account);
        }

        public void UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
