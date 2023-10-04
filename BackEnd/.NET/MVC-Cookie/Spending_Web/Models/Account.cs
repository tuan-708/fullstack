
using System.ComponentModel.DataAnnotations;

namespace Spending_Web.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string AccountName { get; set; }

        public string Password { get; set; }

        public string RePassword { get; set; }

        public string Role { get; set; }

        public bool KeepLoggedIn { get; set; }
    }
}
