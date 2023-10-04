using BussinessObject.BusinessObject;
using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Repository
{
    public class CategorySpendRepository:ICategorySpendRepository
    {
        public List<CategorySpend> getCategorys()
        {
            return CategorySpendDAO.Intance.GetCategorys();
        }
    }
}
