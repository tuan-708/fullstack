using Spending_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spending_Web.DataAccess;

namespace Spending_Web.Repository
{
    public class AccountRepository : IAccountRepository
    {
        // Authen Account
        public Account AuthenAccount(Account account)
        {
            return AccountDAO.Intance.AuthenAccount(account);
        }

        // Delete Account
        public void DeleteAccount(int Id)
        {
            throw new NotImplementedException();
        }

        // Get account by account name
        public Account GetAccountByAccountName(string accountName)
        {
            return AccountDAO.Intance.GetAccountByAccountName(accountName);
        }

        // get all accounts
        public List<Account> getAccounts()
        {
            return AccountDAO.Intance.GetAccounts();
        }

        // insert account
        public void InsertAccount(Account account)
        {
            AccountDAO.Intance.InsertAccount(account);
        }

        // update account
        public void UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
