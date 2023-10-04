using BookStore.Areas.Identity.Data;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace StoreManagement.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        protected readonly StoresManagementContext _context;

        public IndexModel(UserManager<AppUser> userManager, StoresManagementContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public List<AspNetUser> users { get; set; }

        public AspNetUser? user { get; set; }

        public async Task<IActionResult> OnGet()
        {
            users = await _context.AspNetUsers.Include(u => u.Roles).OrderBy(r => r.UserName).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> Onpost(string userid)
        {
            user = _context.AspNetUsers.Include(r => r.Roles).FirstOrDefault(u => u.Id == userid);
            string username = user.UserName;
            if (user == null) return NotFound("Không tìm thấy role");

            _context.AspNetUsers.Remove(user);
            var result = _context.SaveChanges();
            if (result != null)
            {

                user = _context.AspNetUsers.Include(r => r.Roles).FirstOrDefault(u => u.Id == userid);

                StatusMessage = $"Bạn đã xóa thành công: {username}";
            }
            else
            {
                StatusMessage = $"Xóa thất bại.";
            }

            users = await _context.AspNetUsers.Include(u => u.Roles).OrderBy(r => r.UserName).ToListAsync();
            return Page();
        }

    }
}
