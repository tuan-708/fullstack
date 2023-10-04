using Spending_Web.Models;
using Spending_Web.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spending_Web.Repository
{
    public class CategoryRevenueRepository : ICategoryRevenueRepository
    {
        public List<CategoryRevenue> getCategorys()
        {
            return CategoryRevenueDAO.Intance.GetCategorys();
        }
    }
}
