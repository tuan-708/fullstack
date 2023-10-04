using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Pages.Admin.Shippers
{
    public class NewShipperModel : PageModel
    {
        private readonly StoresManagementContext _context;

        public NewShipperModel(StoresManagementContext context)
        {
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public List<Models.Shipper> shippers { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Display(Name = "Tên đơn vị vận chuyển")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string CompanyName { get; set; } = null!;

            [Phone]
            [Display(Name = "Số điện thoại")]
            public string? Phone { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(InputModel input)
        {
            if (ModelState.IsValid)
            {
                Shipper find = _context.Shippers.Where(x => x.CompanyName == input.CompanyName).FirstOrDefault();
                if (find == null)
                {
                    Shipper shipper = new Shipper();
                    shipper.CompanyName = input.CompanyName;
                    shipper.Phone = input.Phone;

                    _context.Shippers.Add(shipper);
                    var result = _context.SaveChanges();
                    if (result != null)
                    {
                        StatusMessage = $"Đã Thêm đơn vị vận chuyển: {input.CompanyName}";
                        return Page();
                    }
                    else
                    {
                        StatusMessage = $"Lỗi thêm đơn vị vận chuyển không thành công: {input.CompanyName}";
                        return Page();
                    }
                }
                else
                {
                    StatusMessage = $"Lỗi Đã tồn tại đơn vị vận chuyển: {input.CompanyName}";
                    return Page();
                }
            }
            return Page();
        }
    }
}
