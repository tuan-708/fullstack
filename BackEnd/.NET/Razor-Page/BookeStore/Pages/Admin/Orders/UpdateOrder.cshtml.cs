using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Pages.Admin.Orders
{
    public class UpdateOrderModel : PageModel
    {
        private readonly StoresManagementContext _context;
        public UpdateOrderModel(StoresManagementContext context)
        {
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public Order Order { get; set; }

        public List<Shipper> Shippers { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Mã đặt hàng")]
            public int OrderId { get; set; }

            [Display(Name = "Email")]
            public string? Email { get; set; }

            [Display(Name = "Id người dùng")]
            public string? UserId { get; set; }

            [Display(Name = "Id nhân viên")]
            public int? EmployeeId { get; set; }

            [Display(Name = "Ngày đặt hàng")]
            public DateTime? OrderDate { get; set; }

            [Display(Name = "Ngày giao hàng")]
            public DateTime? RequiredDate { get; set; }

            [Display(Name = "Ngày đã giao hàng")]
            public DateTime? ShippedDate { get; set; }

            [Display(Name = "Đơn vị giao hàng")]
            public int? ShipVia { get; set; }

            [Display(Name = "Trọng lượng đơn hàng")]
            public decimal? Freight { get; set; }

            [Display(Name = "Người giao hàng")]
            public string? ShipName { get; set; }

            [Display(Name = "Địa chỉ giao hàng")]
            public string? ShipAddress { get; set; }

            [Display(Name = "Thành phố")]
            public string? ShipCity { get; set; }

            [Display(Name = "Khu vực")]
            public string? ShipRegion { get; set; }

            [Display(Name = "Mã code")]
            public string? ShipPostalCode { get; set; }

            [Display(Name = "Đất nước")]
            public string? ShipCountry { get; set; }

            [Display(Name = "Trạng thái:")]
            public string? Status { get; set; }

        }

        public void OnGet(int oid)
        {

            Order = _context.Orders.Include(u => u.User).Include(od => od.OrderDetails).Where(o => o.OrderId == oid).FirstOrDefault();
            if (Order != null)
            {
                Shippers = _context.Shippers.ToList();

                InputModel i = new InputModel();
                i.OrderId = Order.OrderId;
                i.Email = Order.User.Email;
                i.UserId = Order.UserId;
                i.EmployeeId = Order.EmployeeId;
                i.OrderDate = Order.OrderDate;
                i.RequiredDate = Order.RequiredDate;
                i.ShippedDate = Order.ShippedDate;
                i.ShipVia = Order.ShipVia;
                i.Freight = Order.Freight;
                i.ShipName = Order.ShipName;
                i.ShipAddress = Order.ShipAddress;
                i.ShipCity = Order.ShipCity;
                i.ShipRegion = Order.ShipRegion;
                i.ShipPostalCode = Order.ShipPostalCode;
                i.ShipCountry = Order.ShipCountry;
                i.Status = Order.Status;
                Input = i;
            }
        }

        public void reloadPage(int oid)
        {
            Order = _context.Orders.Include(u => u.User).Include(od => od.OrderDetails).Where(o => o.OrderId == oid).FirstOrDefault();
            if (Order != null)
            {
                Shippers = _context.Shippers.ToList();
                InputModel i = new InputModel();
                i.OrderId = Order.OrderId;
                i.Email = Order.User.Email;
                i.UserId = Order.UserId;
                i.EmployeeId = Order.EmployeeId;
                i.OrderDate = Order.OrderDate;
                i.RequiredDate = Order.RequiredDate;
                i.ShippedDate = Order.ShippedDate;
                i.ShipVia = Order.ShipVia;
                i.Freight = Order.Freight;
                i.ShipName = Order.ShipName;
                i.ShipAddress = Order.ShipAddress;
                i.ShipCity = Order.ShipCity;
                i.ShipRegion = Order.ShipRegion;
                i.ShipPostalCode = Order.ShipPostalCode;
                i.ShipCountry = Order.ShipCountry;
                i.Status = Order.Status;
                Input = i;
            }
        }

        public IActionResult OnPost(InputModel input, int oid)
        {
            Order = _context.Orders.Include(u => u.User).Include(od => od.OrderDetails).Where(o => o.OrderId == oid).FirstOrDefault();
            if (Order != null)
            {
                Order.RequiredDate = input.RequiredDate;
                Order.ShippedDate = input.ShippedDate;
                Order.ShipVia = input.ShipVia;
                Order.ShipName = input.ShipName;
                Order.ShipAddress = input.ShipAddress;
                Order.ShipCity = input.ShipCity;
                Order.ShipRegion = input.ShipRegion;
                Order.ShipPostalCode = input.ShipPostalCode;
                Order.ShipCountry = input.ShipCountry;
                Order.Status = input.Status;

                _context.Orders.Update(Order);
                var result = _context.SaveChanges();
                if (result != null)
                {
                    StatusMessage = $"Đã chỉnh sửa đơn hàng: {oid}";
                    reloadPage(oid);
                    return Page();
                }
                else
                {
                    StatusMessage = $"Lỗi chỉnh sửa đơn hàng: {oid}";
                    reloadPage(oid);
                    return Page();
                }
            }
            else
            {
                StatusMessage = $"Lỗi đơn hàng {oid} không tồn tại";
            }

            return Page();
        }

    }
}
