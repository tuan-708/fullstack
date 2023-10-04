using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace BookStore.Pages.Admin.Products.Category
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

        public void OnGet()
        {
            categories =  _context.Categories.ToList();
        }

        public async Task<IActionResult> Onpost(int cid)
        {
 
            Models.Category ca = _context.Categories.FirstOrDefault(c => c.CategoryId == cid);
            if (ca != null)
            {
                string wwwPath = this._webHostEnvironment.WebRootPath;
                string contentPath = this._webHostEnvironment.ContentRootPath;

                string path = Path.Combine(this._webHostEnvironment.WebRootPath, "uploads");

                if (ca.Picture != null)
                {
                    string path1 = Path.Combine(path, ca.Picture);
                    try
                    {
                        if (System.IO.File.Exists(path1))
                        {
                            System.IO.File.Delete(path1);
                        }

                    }
                    catch (IOException ioExp)
                    {
                        Console.WriteLine(ioExp.Message);
                    }
                }


                _context.Categories.Remove(ca);
                var result = await _context.SaveChangesAsync();

                if (result != null)
                {
                    StatusMessage = $"Đã Xóa thể loại: {ca.CategoryName}";
                    categories = _context.Categories.ToList();
                    return Page();
                }
                else
                {
                    StatusMessage = $"Lỗi xóa thể loại không thành công: {ca.CategoryName}";
                    categories = _context.Categories.ToList();
                    return Page();
                }
            }
             
            return Page();
        }
    }
}
