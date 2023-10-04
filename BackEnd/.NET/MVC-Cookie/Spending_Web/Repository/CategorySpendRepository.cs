using Spending_Web.Models;
using Spending_Web.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spending_Web.Repository
{
    public class CategorySpendRepository:ICategorySpendRepository
    {
        public List<CategorySpend> getCategorys()
        {
            return CategorySpendDAO.Intance.GetCategorys();
        }
    }
}
