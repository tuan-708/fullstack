using BookStore.Models;
using BookStore.Pages.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Pages
{
    [Authorize(Roles = "User")]
    public class ViewCartModel : PageModel
    {
        protected readonly StoresManagementContext _context;
        IHubContext<OrderHub> _orderHub;

        public List<Models.Product> Products { get; set; } = new List<Models.Product>();

        public decimal OrderTotal = 0;

        [TempData]
        public string StatusMessage { get; set; }

        public ViewCartModel(StoresManagementContext context, IHubContext<OrderHub> orderHub)
        {
            _orderHub = orderHub;
            _context = context;
        }

        [BindProperty]

        public InputModel Input { get; set; }
        public class InputModel
        {
            [Phone]
            [Display(Name = "Số điện thoại")]
            [Required(ErrorMessage = "Phải nhập số điện thoại")]
            public string? PhoneNumber { get; set; }

            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? ShipAddress { get; set; }

            [Display(Name = "Thành phố")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? ShipCity { get; set; }

            [Display(Name = "Khu vực")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? ShipRegion { get; set; }

            [Display(Name = "Mã code")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(10, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? ShipPostalCode { get; set; }

            [Display(Name = "Đất nước")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string? ShipCountry { get; set; }
        }




        public void OnGet()
        {

            var products = Request.Cookies["ProductCart"];
            if(products != "")
            {
                loadInputModel();

                decimal total = 0;
                var ps = products.Split(".");
                foreach (var p in ps)
                {
                    var id = p.Split('-');
                    Models.Product pro = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == Convert.ToInt32(id[0]));
                    pro.UnitsOnOrder = Convert.ToInt16(id[1]);

                    OrderTotal += (decimal)pro.UnitPrice * Convert.ToInt32(id[1]);

                    Products.Add(pro);
                }
                Page();
            }
        }

        public void loadInputModel()
        {
            string vUserName = User.Identity.Name;
            AspNetUser user = _context.AspNetUsers.Where(u => u.UserName == vUserName).FirstOrDefault();
            InputModel i = new InputModel();
            i.PhoneNumber = user.PhoneNumber == null ? "" : user.PhoneNumber;
            i.ShipAddress = user.Address == null ? "" : user.Address;
            i.ShipCity = user.City == null ? "" : user.City;
            i.ShipRegion = user.Region == null ? "" : user.Region;
            i.ShipPostalCode = user.ShipPostalCode == null ? "" : user.ShipPostalCode;
            i.ShipCountry = user.Country == null ? "" : user.Country;
            Input = i;
        }

        public void OnPost(InputModel input)
        {
            if (ModelState.IsValid)
            {
                var products = Request.Cookies["ProductCart"];
                string vUserName = User.Identity.Name;

                if (products != null)
                {
                    decimal total = 0;
                    var ps = products.Split(".");

                    AspNetUser user = _context.AspNetUsers.Where(u => u.UserName == vUserName).FirstOrDefault();

                    bool check = false;

                    foreach (var p in ps)
                    {
                        var id = p.Split('-');
                        Models.Product pro = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == Convert.ToInt32(id[0]));
                        if (pro.UnitsInStock - Convert.ToInt16(id[1]) < 0)
                        {
                            check = true;
                            StatusMessage = $"Lỗi đơn đặt hàng quá số lượng trong kho: {pro.ProductName}";
                        }

                    }
                    if (check == false)
                    {
                        Order order = new Order();
                        DateTime currentDateTime = DateTime.Now;
                        order.UserId = user.Id;
                        order.OrderDate = currentDateTime;
                        order.PhoneNumber = input.PhoneNumber;
                        order.ShipAddress = input.ShipAddress;
                        order.ShipCity = input.ShipCity;
                        order.ShipRegion = input.ShipRegion;
                        order.ShipPostalCode = input.ShipPostalCode;
                        order.ShipCountry = input.ShipCountry;

                        order.Status = "Xử lý";

                        _context.Orders.Add(order);
                        _context.SaveChanges();

                        decimal Freight = 0;
                        foreach (var p in ps)
                        {
                            var id = p.Split('-');
                            Models.Product pro = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == Convert.ToInt32(id[0]));
                            pro.UnitsOnOrder = (short?)(pro.UnitsOnOrder + Convert.ToInt16(id[1]));
                            pro.UnitsInStock = (short?)(pro.UnitsInStock - Convert.ToInt16(id[1]));

                            _context.Products.Update(pro);
                            _context.SaveChanges();

                            OrderDetail orderDetail = new OrderDetail();
                            orderDetail.OrderId = order.OrderId;
                            orderDetail.ProductId = Convert.ToInt32(id[0]);
                            orderDetail.Quantity = Convert.ToInt16(id[1]);
                            orderDetail.UnitPrice = (decimal)pro.UnitPrice;
                            orderDetail.Discount = 0;

                            Freight += (decimal)pro.UnitPrice;

                            _context.OrderDetails.Add(orderDetail);
                            _context.SaveChanges();

                            Response.Cookies.Delete("ProductCart");

                            _orderHub.Clients.All.SendAsync("UpdateUnitInStock", pro.ProductId, pro.UnitsInStock, pro.UnitsOnOrder);
                        }

                        Order od = _context.Orders.Where(o => o.OrderId == order.OrderId).FirstOrDefault();
                        od.Freight = Freight;

                        _context.Orders.Update(od);
                        _context.SaveChanges();

                        StatusMessage = $"Đơn đặt đơn hàng thành công: {order.OrderId}";
                    }
                }

                OnGet();
            }
            else
            {
                StatusMessage = $"Lỗi đặt đơn hàng.";
            }
            OnGet();
        }
    }
}
