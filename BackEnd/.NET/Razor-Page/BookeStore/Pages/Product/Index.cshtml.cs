using BookStore.Areas.Identity.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Pages.Product
{
    public class IndexModel : PageModel
    {
        protected readonly StoresManagementContext _context;

        public Models.Product Product { get; set; }

        public IndexModel(StoresManagementContext context)
        {
            _context = context;
        }
        public void OnGet(int pid)
        {
            Product = _context.Products.Include(pi => pi.ProductImages).Include(c => c.Category).Include(c => c.Supplier).Where(p => p.ProductId == pid).FirstOrDefault();
            if(Product != null) {
                
            }
        }
    }
}
