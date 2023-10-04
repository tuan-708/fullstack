using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace BookStore.Pages.Admin.Shippers
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {

        private readonly StoresManagementContext _context;

        public IndexModel(StoresManagementContext context)
        {
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public List<Shipper> Shippers { get; set; }

        public void OnGet()
        {
            Shippers = _context.Shippers.ToList();
;       }

        public async Task<IActionResult> Onpost(int sid)
        {
            Shipper find = _context.Shippers.Where( s => s.ShipperId == sid).FirstOrDefault();
            if(find != null) {
                _context.Shippers.Remove(find);
                var result = _context.SaveChanges();
                if (result != null)
                {
                    StatusMessage = $"Đã xóa đơn vị vận chuyển: {find.CompanyName}";
                    Shippers = _context.Shippers.ToList();
                    return Page();
                }
                else
                {
                    StatusMessage = $"Lỗi xóa đơn vị vận chuyển không thành công: {find.CompanyName}";
                    Shippers = _context.Shippers.ToList();
                    return Page();
                }
            }
            else
            {
                StatusMessage = $"Lỗi đơn vị vận chuyển không tồn tại.";
                return Page();
            }
        }
    }
}
