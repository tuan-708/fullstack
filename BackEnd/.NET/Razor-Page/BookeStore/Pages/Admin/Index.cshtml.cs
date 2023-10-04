using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Security.Claims;

namespace StoreManagement.Pages.Admin
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

        public class ObjectBy
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public decimal Amount { get; set; }
        }


        public class Order
        {
            public int OrderID { get; set; }
            public DateTime OrderDate { get; set; }
        }

        public class OrderDetail
        {
            public int OrderID { get; set; }
            public int ProductID { get; set; }
            public int Quantity { get; set; }
        }

        public class Product
        {
            public int ProductID { get; set; }
        }

        public class ObjectBy1
        {
            public int ProductID { get; set; }
            public int Amount { get; set; }
        }

        public List<ObjectBy1> orderproductonday { get; set; }

        public List<AspNetUser> Users { get; set; }

        public int countBand;

        public async Task<IActionResult> OnGetAsync()
        {
            

            var ListRevenueMonthly = _context.Orders
            .Where(order => order.OrderDate.Value.Year == 2023)
            .GroupBy(order => new { Year = order.OrderDate.Value.Year, Month = order.OrderDate.Value.Month })
            .Select(group => new ObjectBy
            {
                Year = group.Key.Year,
                Month = group.Key.Month,
                Amount = (Decimal)group.Sum(order => order.Freight)
            })
            .OrderBy(group => group.Year)
            .ThenBy(group => group.Month)
            .ToList();

            ViewData["ListRevenueMonthly"] = ListRevenueMonthly;

            var RevenueDayly = _context.Orders
                .Where(o =>
                    o.OrderDate.Value.Year == 2023 &&
                    o.OrderDate.Value.Month == 7 &&
                    o.OrderDate.Value.Day == 23)
                .GroupBy(o => new { o.OrderDate.Value.Year, o.OrderDate.Value.Month, o.OrderDate.Value.Day })
                .Select(group => new
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    Day = group.Key.Day,
                    Amount = group.Sum(o => o.Freight)
                })
                .OrderBy(result => result.Year)
                .ThenBy(result => result.Month)
                .ToList();

            ViewData["RevenueDayly"] = RevenueDayly.ElementAt(0).Amount;


            DateTime todayMidnight = DateTime.Now.Date;

            DateTime dateStart = new DateTime(todayMidnight.Year, todayMidnight.Month, todayMidnight.Day).Date;

            orderproductonday = _context.OrderDetails
                .Where(od => od.Order.OrderDate > dateStart)
                .GroupBy(od => od.ProductId)
                .Select(group => new ObjectBy1
                {
                    ProductID = group.Key,
                    Amount = group.Sum(od => od.Quantity)
                })
                .ToList();


            Users = _context.AspNetUsers.ToList();


           
            countBand = 0;

            foreach (var user in Users)
            {
                if(user.Status == "Band")
                {
                    countBand++;
                }
            }



            return Page();
        }
    }
}
