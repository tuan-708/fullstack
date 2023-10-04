using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookStore.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly StoresManagementContext _context;

        public IndexModel(IWebHostEnvironment webHostEnvironment, StoresManagementContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public List<Models.Category> categories { get; set; }

        public List<Models.Supplier> suppliers { get; set; }

        public List<Models.Product> products { get; set; }


        public void OnGet()
        {
            products = _context.Products.Include(c => c.Category).Include(s => s.Supplier).Include(i => i.ProductImages).ToList();
        }

        public async Task<IActionResult> Onpost(int pid)
        {
            if (ModelState.IsValid)
            {
                Models.Product product = _context.Products.FirstOrDefault(p => p.ProductId == pid);
                if (product != null)
                {

                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                    List<ProductImage> images = _context.ProductImages.Where(pi => pi.ProductId == product.ProductId).ToList();
                    foreach (var image in images)
                    {
                        string path1 = Path.Combine(path, image.ProductImage1);
                        try
                        {
                            if (System.IO.File.Exists(path1))
                            {
                                System.IO.File.Delete(path1);
                                _context.ProductImages.Remove(image);
                                _context.SaveChanges();
                            }

                        }
                        catch (IOException ioExp)
                        {
                            Console.WriteLine(ioExp.Message);
                        }
                    }

                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
                products = _context.Products.Include(c => c.Category).Include(s => s.Supplier).Include(i => i.ProductImages).ToList();
                return Page();
            }
            return Page();
        }
    }
}
