using Spending_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spending_Web.Repository
{
    public interface ICategoryRevenueRepository
    {
        List<CategoryRevenue> getCategorys();
   
    }
}
