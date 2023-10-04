using System.ComponentModel.DataAnnotations;
using BookStore.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Số điện thoại")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Họ")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? FirstName { get; set; }

            [Display(Name = "Tên")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? LastName { get; set; }

      
            [Display(Name = "Ngày sinh nhật")]
            public DateTime? Dob { get; set; }

            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? Address { get; set; }

            [Display(Name = "Thành phố")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? City { get; set; }

            [Display(Name = "Khu vực")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? Region { get; set; }

            [Display(Name = "Mã code")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(10, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? ShipPostalCode { get; set; }

            [Display(Name = "Đất nước")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? Country { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Dob = user.Dob,
                Address = user.Address,
                City = user.City,
                Region = user.Region,
                ShipPostalCode = user.ShipPostalCode,
                Country = user.Country,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Không thể tải người dùng có ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(InputModel input)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Không thể tải người dùng có ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (input.PhoneNumber != phoneNumber)
            {
                user.PhoneNumber = input.PhoneNumber;
                user.FirstName = input.FirstName;
                user.LastName = input.LastName;
                user.Dob = input.Dob;
                user.Address = input.Address;
                user.City = input.City;
                user.Region = input.Region;
                user.ShipPostalCode = input.ShipPostalCode;
                user.Country = input.Country;
             
                var result = await _userManager.UpdateAsync(user);
                if(!result.Succeeded)
                {
                    StatusMessage = "Lỗi không mong muốn khi cố gắng thay đổi dữ liệu.";
                    await LoadAsync(user);
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Hồ sơ của bạn đã được cập nhật.";
            return RedirectToPage();
        }
    }
}
