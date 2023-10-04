using Microsoft.AspNetCore.Identity;

namespace BookStore.Areas.Identity.Data
{
    public class AppUser:IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? Dob { get; set; }

        public string? Status { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? ShipPostalCode { get; set; }

        public string? Country { get; set; }
    }
}
