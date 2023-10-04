using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Pages.Admin.Shippers
{
    public class UpdateShipperModel : PageModel
    {
        private readonly StoresManagementContext _context;

        public UpdateShipperModel(StoresManagementContext context)
        {
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public Shipper Shipper { get; set; }


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



        public void OnGet(InputModel input, int sid)
        {
            Shipper find = _context.Shippers.Where(s => s.ShipperId == sid).FirstOrDefault();
            if(find != null)
            {
                InputModel i = new InputModel();
                i.CompanyName = find.CompanyName;
                i.Phone = find.Phone;
                Input = i;
            }
            else
            {
                StatusMessage = $"Lỗi đơn vị vận chuyển không tồn tại.";
            }
        }

        public async Task<IActionResult> OnPost(InputModel input, int sid)
        {
            if (ModelState.IsValid)
            {
                Shipper find = _context.Shippers.Where(s => s.ShipperId == sid).FirstOrDefault();
                if (find != null)
                {
                    find.CompanyName = input.CompanyName;
                    find.Phone = input.Phone;

                    Shipper find1 = _context.Shippers.Where(x => x.CompanyName == input.CompanyName).FirstOrDefault();
                    if(find1 == null)
                    {
                        _context.Update(find);
                        var result = _context.SaveChanges();
                        if (result != null)
                        {
                            StatusMessage = $"Đã chỉnh sửa đơn vị vận chuyển: {input.CompanyName}";
                            return Page();
                        }
                        else
                        {
                            StatusMessage = $"Lỗi chỉnh sửa đơn vị vận chuyển không thành công: {input.CompanyName}";
                            return Page();
                        }
                    }
                    else
                    {
                        StatusMessage = $"Lỗi đơn vị vận chuyển đã tồn tại.";
                    }
                }
                else
                {
                    StatusMessage = $"Lỗi đơn vị vận chuyển không tồn tại.";
                }
            }

            return Page();
        }
    }
}
