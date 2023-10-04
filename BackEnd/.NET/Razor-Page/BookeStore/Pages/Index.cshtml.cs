using BookStore.Areas.Identity.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace BookeStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        protected readonly StoresManagementContext _context;

        public IndexModel(UserManager<AppUser> userManager, StoresManagementContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public List<BookStore.Models.Product> products { get; set; }

        public List<BookStore.Models.Category> categories { get; set; }

        public List<BookStore.Models.Supplier> suppliers { get; set; }

        public void OnGet()
        {
            products = _context.Products.Include(pi => pi.ProductImages).Include(c => c.Category).ToList();
       }
    }
}