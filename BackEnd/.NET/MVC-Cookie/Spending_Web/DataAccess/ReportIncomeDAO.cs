using Spending_Web.Models;
using Microsoft.Data.SqlClient;
using Spending_Web.Models;
using System.Data;
using System.Text.RegularExpressions;

namespace Spending_Web.DataAccess
{
    public class ReportIncomeDAO:DBContext
    {
        public static string connection = GetConnection();

        public ReportIncomeDAO() { }


        public static ReportIncomeDAO Intance = new ReportIncomeDAO();

        // Get all transaction revenue account
        public List<ReportIncome> GetListRevenueMonthly(Account account)
        {
            IDataReader dataReader = null;
            string SQLSelect = "SELECT YEAR(date_revenue) As [Year], MONTH(date_revenue) As [Month], SUM(amount) As Amount FROM [transaction_revenue] where id_account = @IdAccount and YEAR(date_revenue) = @Year GROUP BY YEAR(date_revenue), MONTH(date_revenue) ORDER BY [Year], [Month]";
            var reportIncomes = new List<ReportIncome>();
            try
            {
                DateTime dateTime = DateTime.Now;
                var parameters = new List<SqlParameter>();
                parameters.Add(CreateParameter("@IdAccount", 50, account.Id, DbType.Int32));
                parameters.Add(CreateParameter("@Year", 50, dateTime.Year, DbType.Int32));


                dataReader = GetDataReader(SQLSelect, CommandType.Text, connection, parameters.ToArray());
                while (dataReader.Read())
                {
                    reportIncomes.Add(new ReportIncome
                    {
                        Year = dataReader.GetInt32(0),
                        Month = dataReader.GetInt32(1),
                        AmountRevenue = dataReader.GetDecimal(2),
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
            return reportIncomes;
        }

        public List<ReportIncome> GetListSpendMonthly(Account account)
        {
            IDataReader dataReader = null;
            string SQLSelect = "SELECT YEAR(date_spend) As [Year], MONTH(date_spend) As [Month], SUM(amount) As Amount FROM [transaction_spend] where id_account = @IdAccount and YEAR(date_spend) = @Year GROUP BY YEAR(date_spend), MONTH(date_spend) ORDER BY [Year], [Month]";
            var reportIncomes = new List<ReportIncome>();
            try
            {
                DateTime dateTime = DateTime.Now;
                var parameters = new List<SqlParameter>();
                parameters.Add(CreateParameter("@IdAccount", 50, account.Id, DbType.Int32));
                parameters.Add(CreateParameter("@Year", 50, dateTime.Year, DbType.Int32));
                
                dataReader = GetDataReader(SQLSelect, CommandType.Text, connection, parameters.ToArray());
                while (dataReader.Read())
                {
                    reportIncomes.Add(new ReportIncome
                    {
                        Year = dataReader.GetInt32(0),
                        Month = dataReader.GetInt32(1),
                        AmountSpend = dataReader.GetDecimal(2),
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
            return reportIncomes;
        }
    }
}
