using Spending_Web.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spending_Web.DataAccess
{
    public class TransactionSpendDAO:DBContext
    {
        public static string connection = GetConnection();

        public TransactionSpendDAO() { }

        public static TransactionSpendDAO Intance = new TransactionSpendDAO();

        // Get all transaction spend account
        public List<TransactionSpend> GetListTransactionSpendAccount(Account account, DateTime DTFrom, DateTime DTTo)
        {
            IDataReader dataReader = null;
            string SQLSelect = "select transaction_spend.id as Id, date_spend, amount, decription, category, id_account " +
                "from transaction_spend where transaction_spend.id_account = @IdAccount and date_spend >= @DTFrom and date_spend <= @DTTo order by date_spend desc";
            var transactionSpends = new List<TransactionSpend>();
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(CreateParameter("@IdAccount", 50, account.Id, DbType.Int32));
                parameters.Add(CreateParameter("@DTFrom", 50, DTFrom, DbType.String));
                parameters.Add(CreateParameter("@DTTo", 50, DTTo, DbType.String));

                dataReader = GetDataReader(SQLSelect, CommandType.Text, connection, parameters.ToArray());
                while (dataReader.Read())
                {
                    transactionSpends.Add(new TransactionSpend
                    {
                        Id = dataReader.GetInt32(0),
                        DateSpend = dataReader.GetDateTime(1),
                        Amount = dataReader.GetDecimal(2),
                        Description = dataReader.GetString(3),
                        CategorySpend = dataReader.GetString(4),
                        IdAccount = dataReader.GetInt32(5)
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
            return transactionSpends;
        }

        // Insert Account
        public void InsertStransactionSpend(TransactionSpend transaction)
        {
            try
            {
                String SQLInsert = "INSERT INTO [dbo].[transaction_spend]([date_spend],[amount],[decription],[category],[id_account]) VALUES (@DateSpend,@Amount,@Description,@CategorySpend,@IdAccount)";
                var parameters = new List<SqlParameter>();
                parameters.Add(CreateParameter("@DateSpend", 50, transaction.DateSpend, DbType.DateTime));
                parameters.Add(CreateParameter("@Amount", 50, transaction.Amount, DbType.Decimal));
                parameters.Add(CreateParameter("@Description", 50, transaction.Description, DbType.String));
                parameters.Add(CreateParameter("@CategorySpend", 50, transaction.CategorySpend, DbType.String));
                parameters.Add(CreateParameter("@IdAccount", 50, transaction.IdAccount, DbType.Int32));
                Insert(SQLInsert, CommandType.Text, connection, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void DeleteStransactionSpend(int idTransaction)
        {
            try
            {
                String SQLInsert = "delete transaction_spend where id = @idTransaction";
                var parameters = new List<SqlParameter>();
                parameters.Add(CreateParameter("@idTransaction", 50, idTransaction, DbType.Int32));
                Delete(SQLInsert, CommandType.Text, connection, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateTransactionSpend(TransactionSpend transaction)
        {
            try
            {
                String SQLInsert = "update transaction_spend set date_spend = @DateSpend, amount = @Amount, decription = @Description, category = @CategorySpend, id_account = @IdAccount where id = @Id";
                var parameters = new List<SqlParameter>();
                parameters.Add(CreateParameter("@DateSpend", 50, transaction.DateSpend, DbType.DateTime));
                parameters.Add(CreateParameter("@Amount", 50, transaction.Amount, DbType.Decimal));
                parameters.Add(CreateParameter("@Description", 50, transaction.Description, DbType.String));
                parameters.Add(CreateParameter("@CategorySpend", 50, transaction.CategorySpend, DbType.String));
                parameters.Add(CreateParameter("@IdAccount", 50, transaction.IdAccount, DbType.Int32));
                parameters.Add(CreateParameter("@Id", 50, transaction.Id, DbType.Int32));
                Update(SQLInsert, CommandType.Text, connection, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
