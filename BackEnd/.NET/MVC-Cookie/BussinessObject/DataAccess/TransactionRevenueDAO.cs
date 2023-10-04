using BussinessObject.BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BussinessObject.DataAccess
{
    public class TransactionRevenueDAO:DBContext
    {
        public static string connection = GetConnection();

        public TransactionRevenueDAO() { }


        public static TransactionRevenueDAO Intance = new TransactionRevenueDAO();

        // Get all transaction revenue account
        public List<TransactionRevenue> GetListTransactionRevenueAccount(Account account, DateTime DTFrom, DateTime DTTo)
        {
            IDataReader dataReader = null;
            string SQLSelect = "select transaction_revenue.id as Id, date_revenue, amount, decription, category, id_account " +
                "from transaction_revenue where transaction_revenue.id_account = @IdAccount and date_revenue >= @DTFrom and date_revenue <= @DTTo order by date_revenue desc";
            var transactionRevenues = new List<TransactionRevenue>();
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(CreateParameter("@IdAccount", 50, account.Id, DbType.Int32));
                parameters.Add(CreateParameter("@DTFrom", 50, DTFrom, DbType.DateTime));
                parameters.Add(CreateParameter("@DTTo", 50, DTTo, DbType.DateTime));


                dataReader = GetDataReader(SQLSelect, CommandType.Text, connection, parameters.ToArray());
                while (dataReader.Read())
                {
                    transactionRevenues.Add(new TransactionRevenue
                    {
                        Id = dataReader.GetInt32(0),
                        DateRevenue = dataReader.GetDateTime(1),
                        Amount = dataReader.GetDecimal(2),
                        Description = dataReader.GetString(3),
                        CategoryRevenue = dataReader.GetString(4),
                        IdAccount = dataReader.GetInt32(5),
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
            return transactionRevenues;
        }


        // Insert Account
        public void InsertStransactionRevenue(TransactionRevenue transaction)
        {
            try
            {
                String SQLInsert = "INSERT INTO [dbo].[transaction_revenue]([date_revenue],[amount],[decription],[category],[id_account]) VALUES(@DateRevenue,@Amount,@Description,@CategoryRevenue,@IdAccount)";
                var parameters = new List<SqlParameter>();
                parameters.Add(CreateParameter("@DateRevenue", 50, transaction.DateRevenue, DbType.DateTime));
                parameters.Add(CreateParameter("@Amount", 50, transaction.Amount, DbType.Decimal));
                parameters.Add(CreateParameter("@Description", 50, transaction.Description, DbType.String));
                parameters.Add(CreateParameter("@CategoryRevenue", 50, transaction.CategoryRevenue, DbType.String));
                parameters.Add(CreateParameter("@IdAccount", 50, transaction.IdAccount, DbType.Int32));
                Insert(SQLInsert, CommandType.Text, connection, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // delete transaction revenue account
        public void DeleteTransactionRevenue(int idTransaction)
        {
            try
            {
                String SQLInsert = "delete transaction_revenue where id = @idTransaction";
                var parameters = new List<SqlParameter>();
                parameters.Add(CreateParameter("@idTransaction", 50, idTransaction, DbType.Int32));
                Delete(SQLInsert, CommandType.Text, connection, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // update transaction revenue account
        public void UpdateTransactionRevenue(TransactionRevenue transaction)
        {
            try
            {   
                String SQLInsert = "update transaction_revenue set date_revenue = @DateRevenue, amount = @Amount, decription = @Description, category = @CategoryRevenue, id_account = @IdAccount where id = @Id";
                var parameters = new List<SqlParameter>();
                parameters.Add(CreateParameter("@DateRevenue", 50, transaction.DateRevenue, DbType.DateTime));
                parameters.Add(CreateParameter("@Amount", 50, transaction.Amount, DbType.Decimal));
                parameters.Add(CreateParameter("@Description", 50, transaction.Description, DbType.String));
                parameters.Add(CreateParameter("@CategoryRevenue", 50, transaction.CategoryRevenue, DbType.String));
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
