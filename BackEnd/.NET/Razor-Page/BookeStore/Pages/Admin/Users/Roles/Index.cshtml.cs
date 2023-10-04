using BookStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreManagement.Pages.Admin.Users.Roles
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public List<IdentityRole> roles { get; set; }

        public void OnGet()
        {
            roles = _roleManager.Roles.OrderBy(r => r.Name ).ToList();

        }

        public async Task<IActionResult> Onpost(string rid)
        {
            var role = await _roleManager.FindByIdAsync(rid);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    StatusMessage = $"Bạn vừa xóa: {role.Name}";
                    return Redirect("~/Admin/Users/Roles");
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
            return Page();
        }
    }
}
