using Spending_Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Spending_Web.DataAccess
{
    public class CategorySpendDAO: DBContext
    {
        // get connection DB
        public static string connection = GetConnection();

        public CategorySpendDAO() { }

        public static CategorySpendDAO Intance = new CategorySpendDAO();

        public List<CategorySpend> GetCategorys()
        {
            IDataReader dataReader = null;
            string SQLSelect = "select * from category_spend;";
            var categorys = new List<CategorySpend>();
            try
            {
                dataReader = GetDataReader(SQLSelect, CommandType.Text, connection);
                while (dataReader.Read())
                {
                    categorys.Add(new CategorySpend
                    {
                        Id = dataReader.GetInt32(0),
                        Category = dataReader.GetString(1),
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
            return categorys;
        }
    }
}
