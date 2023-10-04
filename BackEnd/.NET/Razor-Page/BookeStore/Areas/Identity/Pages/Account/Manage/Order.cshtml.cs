using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Octokit;

namespace BookStore.Areas.Identity.Pages.Account.Manage
{
    public class OrderModel : PageModel
    {
        private readonly StoresManagementContext _context;
        public OrderModel(StoresManagementContext context)
        {
            _context = context;
        }

        public List<Order> Orders { get; set; }

        public List<Shipper> Shippers { get; set; }

        [TempData]
        public string StatusMessage { get; set; }


        public void OnGet()
        {
            string IdentityEmail = User.Identity.Name;
            AspNetUser user = _context.AspNetUsers.Where(u => u.UserName == IdentityEmail).FirstOrDefault();
            if (user.Email == IdentityEmail)
            {
                Shippers = _context.Shippers.ToList();

                Orders = _context.Orders.Include(od => od.OrderDetails).Where(u => u.UserId == user.Id).ToList();
            }
        }

        public IActionResult OnPost(int oid)
        {
            string IdentityEmail = User.Identity.Name;
            AspNetUser user = _context.AspNetUsers.Where(u => u.UserName == IdentityEmail).FirstOrDefault();
            if (user.Email == IdentityEmail)
            {
                Order find = _context.Orders.Where(u => u.UserId == user.Id && u.OrderId == oid).FirstOrDefault();
                if(find != null)
                {
                    find.Status = "Đã hủy";
                    _context.Update(find);
                    var result = _context.SaveChanges();
                    if (result != null)
                    {
                        StatusMessage = $"Đã hủy đơn hàng: {oid}";
                    }
                    else
                    {
                        StatusMessage = $"Lỗi hủy đơn hàng: {oid}";
                    }
                }
                else
                {
                    StatusMessage = $"Lỗi bạn không có đơn hàng: {oid}";
                }
            }


            Shippers = _context.Shippers.ToList();

            Orders = _context.Orders.Include(od => od.OrderDetails).Where(u => u.UserId == user.Id).ToList();
            
            return Page();

        }
    }
}
