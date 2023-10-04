using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BookStore.Pages.Admin.Products.Supplier
{
    [Authorize(Roles = "Admin")]
    public class UpdateSupplierModel : PageModel
    {
        private readonly StoresManagementContext _context;

        public UpdateSupplierModel(StoresManagementContext context)
        {
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            public int SupplierId { get; set; }

            [Display(Name = "Tên công ty")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string CompanyName { get; set; } = null!;

            [Display(Name = "Tên hợp đồng")]
            public string? ContactName { get; set; }

            [Display(Name = "Tiêu đề hợp đồng")]
            public string? ContactTitle { get; set; }

            [Display(Name = "Địa chỉ")]
            public string? Address { get; set; }

            [Display(Name = "Thành phố")]
            public string? City { get; set; }

            [Display(Name = "Khu vực")]
            public string? Region { get; set; }

            [Display(Name = "Postal Code")]
            public string? PostalCode { get; set; }

            [Display(Name = "Thành phố")]
            public string? Country { get; set; }

            [Display(Name = "Điện thoại")]
            public string? Phone { get; set; }

            [Display(Name = "Mã số thuế")]
            public string? Fax { get; set; }

            [Display(Name = "Trang web")]
            public string? HomePage { get; set; }
        }
        public void OnGet(int sid)
        {
            Models.Supplier supplier = _context.Suppliers.FirstOrDefault(c => c.SupplierId == sid);
            if (supplier != null)
            {
                InputModel i = new InputModel();
                i.CompanyName = supplier.CompanyName;
                i.ContactName = supplier.ContactName;
                i.ContactTitle = supplier.ContactTitle;
                i.Address = supplier.Address;
                i.City = supplier.City;
                i.Region = supplier.Region;
                i.PostalCode = supplier.PostalCode;
                i.Country = supplier.Country;
                i.Phone = supplier.Phone;
                i.Fax = supplier.Fax;
                i.HomePage = supplier.HomePage;
                Input = i;
            }
        }

        public async Task<IActionResult> OnPost(InputModel input, int sid)
        {
            if (ModelState.IsValid)
            {
                Models.Supplier supplier = _context.Suppliers.FirstOrDefault(c => c.SupplierId == sid);
                if (supplier != null)
                {
                    supplier.CompanyName = input.CompanyName;
                    supplier.ContactName = input.ContactName;
                    supplier.ContactTitle = input.ContactTitle;
                    supplier.Address = input.Address;
                    supplier.City = input.City;
                    supplier.Region = input.Region;
                    supplier.PostalCode = input.PostalCode;
                    supplier.Country = input.Country;
                    supplier.Phone = input.Phone;
                    supplier.Fax = input.Fax;
                    supplier.HomePage = input.HomePage;

                    Models.Supplier find1 = _context.Suppliers.Where(s => s.CompanyName == input.CompanyName).FirstOrDefault();
                    if (find1 == null)
                    {
                        _context.Update(supplier);
                        var result = _context.SaveChanges();
                        if (result != null)
                        {
                            StatusMessage = $"Đã chỉnh sửa đơn vị cung cấp: {input.CompanyName}";
                            return Page();
                        }
                        else
                        {
                            StatusMessage = $"Lỗi chỉnh sửa đơn vị cung cấp không thành công: {input.CompanyName}";
                            return Page();
                        }
                    }
                    else
                    {
                        StatusMessage = $"Lỗi chỉnh sửa đơn vị cung cấp không thành công: {input.CompanyName}";
                    }
                }
                else
                {
                    StatusMessage = $"Không tồn tại đơn vị cung cấp.";
                }
            }

            return Page();
        }
    }
}
