using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace BookStore.Pages.Admin.Products.Supplier
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly StoresManagementContext _context;

        public IndexModel(StoresManagementContext context)
        {
            _context = context;
        }

        public List<Models.Supplier> Suppliers { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public void OnGet()
        {
            Suppliers = _context.Suppliers.ToList();
        }

        public async Task<IActionResult> Onpost(int sid)
        {
            var supplier = _context.Suppliers.FirstOrDefault(c => c.SupplierId == sid);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                var result = _context.SaveChanges();
                if (result != null)
                {
                    StatusMessage = $"Đã xóa đơn vị cung cấp: {supplier.CompanyName}";
                    Suppliers = _context.Suppliers.ToList();
                    return Page();
                }
                else
                {
                    StatusMessage = $"Lỗi xóa đơn vị cung cấp không thành công: {supplier.CompanyName}";
                    Suppliers = _context.Suppliers.ToList();
                    return Page();
                }
            }
            else
            {
                StatusMessage = $"Lỗi đơn vị cung cấp không tồn tại.";
                return Page();
            }

 
        }
    }
}
