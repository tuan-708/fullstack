using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using BussinessObject.BusinessObject;
using Microsoft.Data.SqlClient;

namespace BussinessObject.DataAccess
{
    public class AccountDAO: DBContext
    {
        public static string connection = GetConnection();

        public static AccountDAO Intance = new AccountDAO();

        public AccountDAO() { }

        // get all accounts
        public List<Account> GetAccounts()
        {
            IDataReader dataReader = null;
            string SQLSelect = "select id, account_name, password, role from account;";
            var accounts = new List<Account>();
            try
            {
                dataReader = GetDataReader(SQLSelect, CommandType.Text, connection);
                while (dataReader.Read())
                {
                    accounts.Add(new Account
                    {
                        Id = dataReader.GetInt32(0),
                        AccountName = dataReader.GetString(1),
                        Password = dataReader.GetString(2),
                        Role = dataReader.GetString(3),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
            }
            return accounts;
        }

        // Authentication account
        public Account AuthenAccount(Account account)
        {
            Account authAcccount = null;
            IDataReader dataReader = null;
            string SQLSelect = "select * from account where account_name = @AccountName and password = @Password";
            var parameters = new List<SqlParameter>();
            parameters.Add(CreateParameter("@AccountName", 50, account.AccountName, DbType.String));
            parameters.Add(CreateParameter("@Password", 50, account.Password, DbType.String));

            try
            {
                dataReader = GetDataReader(SQLSelect, CommandType.Text, connection, parameters.ToArray());
                if (dataReader.Read())
                {
                    authAcccount =  new Account
                    {
                        Id = dataReader.GetInt32(0),
                        AccountName = dataReader.GetString(1),
                        Password = dataReader.GetString(2),
                        Role = dataReader.GetString(3),
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
            }
            return authAcccount;
        }

        // Check account exist
        public Account GetAccountByAccountName(string accountName)
        {
            Account authAcccount = null;
            IDataReader dataReader = null;
            string SQLSelect = "select * from account where account_name = @AccountName";
            var parameters = new List<SqlParameter>();
            parameters.Add(CreateParameter("@AccountName", 50, accountName, DbType.String));
            try
            {
                dataReader = GetDataReader(SQLSelect, CommandType.Text, connection, parameters.ToArray());
                if (dataReader.Read())
                {
                    authAcccount = new Account
                    {
                        Id = dataReader.GetInt32(0),
                        AccountName = dataReader.GetString(1),
                        Password = dataReader.GetString(2),
                        Role = dataReader.GetString(3),
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
            }
            return authAcccount;
        }

        // Insert Account
        public void InsertAccount(Account account)
        {
            try
            {
                String SQLInsert = "INSERT INTO account (account_name, password, role) VALUES (@AccountName, @Password, @Role);";
                var parameters = new List<SqlParameter>();
                parameters.Add(CreateParameter("@AccountName", 50, account.AccountName, DbType.String));
                parameters.Add(CreateParameter("@Password", 50, account.Password, DbType.String));
                parameters.Add(CreateParameter("@Role", 50, account.Role, DbType.String));
                Insert(SQLInsert, CommandType.Text,connection, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
