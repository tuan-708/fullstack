using BussinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Repository
{
    public interface ICategorySpendRepository
    {
        List<CategorySpend> getCategorys();
    }
}
