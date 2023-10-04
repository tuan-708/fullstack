using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BookStore.Pages.Admin.Products.Supplier
{
    [Authorize(Roles = "Admin")]
    public class NewSupplierModel : PageModel
    {
        private readonly StoresManagementContext _context;

        public NewSupplierModel(StoresManagementContext context)
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

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(InputModel input)
        {
            if(ModelState.IsValid)
            {
                Models.Supplier find = _context.Suppliers.Where(s => s.CompanyName == input.CompanyName).FirstOrDefault();
                if(find == null)
                {
                    Models.Supplier supplier = new Models.Supplier();
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

                    _context.Suppliers.Add(supplier);
                    var result = _context.SaveChanges();
                    if (result != null)
                    {
                        StatusMessage = $"Đã thêm đơn vị cung cấp: {input.CompanyName}";
                        return Page();
                    }
                    else
                    {
                        StatusMessage = $"Lỗi thêm đơn vị cung cấp không thành công: {input.CompanyName}";
                        return Page();
                    }
                }
                else
                {
                    StatusMessage = $"Lỗi Đã tồn tại đơn vị cung cấp: {input.CompanyName}";
                    return Page();
                }
                
            }
            return Page();
        }
    }
}
