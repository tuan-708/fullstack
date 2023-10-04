using BookStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Pages.Admin.Users.Roles
{
    [Authorize(Roles="Admin")]
    public class CreateModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Tên vai trò")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(256, MinimumLength = 3, ErrorMessage ="{0} phải dài {2} đến {1} ký tự")]
            public string Name { get; set; }
        }


        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnpostAsync(InputModel input)
        {
            var find = _roleManager.FindByNameAsync(input.Name);
            if(find == null)
            {
                var newRole = new IdentityRole(input.Name);
                var result = await _roleManager.CreateAsync(newRole);

                if (result.Succeeded)
                {
                    StatusMessage = $"Bạn vừa tạo role mới: {input.Name}";
                    return Page();
                }
                else
                {
                    result.Errors.ToList().ForEach(error =>
                    {

                        ModelState.AddModelError(string.Empty, error.Description);
                    });
                }
            }
            else
            {
                StatusMessage = $"Lỗi đã tồn tại: {input.Name}";
                return Page();
            }

            

            return Page();
        }
    }
}
