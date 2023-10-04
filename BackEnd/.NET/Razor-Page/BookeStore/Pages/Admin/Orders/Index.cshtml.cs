using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BookStore.Pages.Admin.Orders
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly StoresManagementContext _context;
        public IndexModel(StoresManagementContext context)
        {
            _context = context;
        }

        public List<Order> Orders { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Display(Name = "Trạng thái")]
            public string? Status { get; set; }

            [Display(Name = "Lọc theo ngày tháng")]
            public string? OrderByDaybyMonth { get; set; }
        }

        public DateTime getDateFillter(string OrderByDaybyMonth)
        {
            DateTime DTTo;
            DateTime DTFrom;

            DTTo = DateTime.Now;

            TimeSpan aInterval = new TimeSpan(30, 0, 0, 0);

            DTFrom = DTTo.Subtract(aInterval);

            if (OrderByDaybyMonth == "Hôm nay")
            {
                DTTo = DateTime.Now;

                DTFrom = new DateTime(DTTo.Year, DTTo.Month, DTTo.Day - 1, 23, 59, 59);
            }
            else if (OrderByDaybyMonth == "1 Tuần này")
            {
                DTTo = DateTime.Now;

                int startOfWeek = (int)DayOfWeek.Monday;
                int daysSinceStartOfWeek = ((int)DTTo.DayOfWeek + 7 - startOfWeek) % 7;

                DTFrom = DTTo.AddDays(-daysSinceStartOfWeek);
                DTFrom = new DateTime(DTFrom.Year, DTFrom.Month, DTFrom.Day - 1, 23, 59, 59);
            }
            else if (OrderByDaybyMonth == "1 Tháng này")
            {
                DTTo = DateTime.Now;
                DTFrom = new DateTime(DTTo.Year, DTTo.Month, 1);

            }

            return DTFrom;
        }

        public void OnGet(InputModel input)
        {
            if (input.Status != null && input.OrderByDaybyMonth != null)
            {
                DateTime DTTo = DateTime.Now;
                DateTime DTFrom = getDateFillter(input.OrderByDaybyMonth);

                Orders = _context.Orders.Include(u => u.User).Include(od => od.OrderDetails).Where(o => o.Status == input.Status && o.OrderDate > DTFrom && o.OrderDate < DTTo).ToList();
            }

            if(input.OrderByDaybyMonth == null && input.Status  == null)
            {
                Orders = _context.Orders.Include(u => u.User).Include(od => od.OrderDetails).Take(1000).ToList();
            }
        }

        public IActionResult OnPost(int oid)
        {
            Order find = _context.Orders.Include(u => u.User).Include(od => od.OrderDetails).Where(o => o.OrderId == oid).FirstOrDefault();
            if (find != null)
            {
                var od = _context.OrderDetails.Include(od => od.Product).Where(o => o.OrderId == find.OrderId).FirstOrDefault();
                _context.OrderDetails.Remove(od);
                _context.SaveChanges();

                _context.Orders.Remove(find);
                var result = _context.SaveChanges();
                if (result != null)
                {
                    StatusMessage = $"Đã xóa đơn hàng: {oid}";
                }
                else
                {
                    StatusMessage = $"Lỗi xóa đơn hàng: {oid}";
                }
            }
            Orders = _context.Orders.Include(u => u.User).Include(od => od.OrderDetails).Take(1000).ToList();
            return Page();
        }
    }
}
