using BookStore.Areas.Identity.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookStore.Pages.Admin.Users
{
    public class UpdateUserRoleModel : PageModel
    {

        private readonly UserManager<AppUser> _userManager;
        protected readonly StoresManagementContext _context;

        public UpdateUserRoleModel(UserManager<AppUser> userManager, StoresManagementContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public AspNetUser? user { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public List<AspNetRole> roles { get; set; }

        public async Task<IActionResult> OnGet(string userid)
        {
            user = _context.AspNetUsers.Include(r => r.Roles).FirstOrDefault(u => u.Id == userid);
            if (user == null) return NotFound("Không tìm thấy role");
            else
            {
                roles = _context.AspNetRoles.ToList();
               
            }
   
            return Page();
        }

        public async Task<IActionResult> OnpostAsync(IEnumerable<string> selectedValues, string userid)
        {
            var u = await _userManager.FindByIdAsync(userid);
            roles = _context.AspNetRoles.ToList();

            if (u == null) return NotFound("Không tìm thấy role");

            foreach (var role in roles)
            {
                var r = await _userManager.RemoveFromRoleAsync(u, role.Name);
            }

            var result = await _userManager.AddToRolesAsync(u, selectedValues);

            if (result.Succeeded)
            {

                user = _context.AspNetUsers.Include(r => r.Roles).FirstOrDefault(u => u.Id == userid);

                StatusMessage = $"Bạn thay đổi thành công vai trò: {u.UserName}";
                return Page();
            }
            else
            {
                result.Errors.ToList().ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                });
            }


            return Page();
        }
    }
}
