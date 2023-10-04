using BussinessObject.BusinessObject;
using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Repository
{
    public class CategoryRevenueRepository : ICategoryRevenueRepository
    {
        public List<CategoryRevenue> getCategorys()
        {
            return CategoryRevenueDAO.Intance.GetCategorys();
        }
    }
}
