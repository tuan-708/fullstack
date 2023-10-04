using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.BusinessObject
{
    public class Account
    {
        public Account() { }

        public int Id { get; set; }

        public string AccountName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
