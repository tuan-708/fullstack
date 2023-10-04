using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BookStore.Pages.Admin.Products.Product
{
    [Authorize(Roles = "Admin")]
    public class UpdateProductModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly StoresManagementContext _context;

        public UpdateProductModel(IWebHostEnvironment webHostEnvironment, StoresManagementContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public List<Models.Category> categories { get; set; }

        public List<Models.Supplier> suppliers { get; set; }

        public List<string> uploadedFiles = new List<string>();

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Tên sản phẩm")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string ProductName { get; set; } = null!;

            [Display(Name = "Tên thể loại")]
            public int? SupplierId { get; set; }

            [Display(Name = "Tên nhà cung cấp")]
            public int? CategoryId { get; set; }

            [Display(Name = "Miêu tả")]
            public string? Describe { get; set; }

            [Display(Name = "Tác giả")]
            public string? Author { get; set; }

            [Display(Name = "Số lượng mỗi đơn vị")]
            public string? QuantityPerUnit { get; set; }

            [Display(Name = "Đơn giá")]
            public decimal? UnitPrice { get; set; }

            [Display(Name = "Số lượng trong kho")]
            public short? UnitsInStock { get; set; }

            [Display(Name = "Số lượng đặt hàng")]
            public short? UnitsOnOrder { get; set; }

            [Display(Name = "Số lượng đặt hàng")]
            public short? ReorderLevel { get; set; }

            [Display(Name = "Trạng thái")]
            public bool Discontinued { get; set; }


            [Display(Name = "Choose the cover photo of your book")]
            [Required]
            public IFormFile CoverPhoto { get; set; }
            public string CoverImageUrl { get; set; }
        }


        public void OnGet(int pid)
        {
            Models.Product product = _context.Products.FirstOrDefault(p => p.ProductId == pid);
            if(product != null)
            {
                InputModel i = new InputModel();
                i.ProductName = product.ProductName;
                i.SupplierId = product.SupplierId;
                i.CategoryId = product.CategoryId;
                i.Describe = product.Describe;
                i.Author = product.Author;
                i.QuantityPerUnit = product.QuantityPerUnit;
                i.UnitPrice = product.UnitPrice;
                i.UnitsInStock = product.UnitsInStock;
                i.UnitsOnOrder = product.UnitsOnOrder;
                i.ReorderLevel = product.ReorderLevel;
                i.Discontinued = product.Discontinued;

                Input = i;

                var list = _context.ProductImages.Where(pi => pi.ProductId == product.ProductId).Select(e => new { e.ProductImage1 }).ToList();
                foreach (var image in list)
                {
                    uploadedFiles.Add(image.ProductImage1);
                }


            }
            categories = _context.Categories.ToList();
            suppliers = _context.Suppliers.ToList();
        }

        public IActionResult OnPost(List<IFormFile> postedFiles, InputModel input, int pid)
        {
            Models.Product product = _context.Products.FirstOrDefault(p => p.ProductId == pid);
            if (product != null)
            {
                if(postedFiles.Count > 0)
                {
                    string path = Path.Combine(this._webHostEnvironment.WebRootPath, "uploads");

                    var Imagelist = _context.ProductImages.Where(pi => pi.ProductId == product.ProductId).ToList();

                    foreach (var image in Imagelist)
                    {
                        string path1 = Path.Combine(path, image.ProductImage1);
                        try
                        {
                            if (System.IO.File.Exists(path1))
                            {
                                System.IO.File.Delete(path1);

                                _context.ProductImages.Remove(image);
                                _context.SaveChanges();
                            }
                            else
                            {
                                _context.ProductImages.Remove(image);
                                _context.SaveChanges();
                            }

                        }
                        catch (IOException ioExp)
                        {
                            Console.WriteLine(ioExp.Message);
                        }
                    }


                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    foreach (IFormFile postedFile in postedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        var name = fileName.Split(".");
                        fileName = Guid.NewGuid().ToString() + "." + name[1];
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);

                            Models.ProductImage pi = new Models.ProductImage();
                            pi.ProductId = product.ProductId;
                            pi.ProductImage1 = fileName;
                            _context.ProductImages.Add(pi);
                            _context.SaveChanges();
                        }
                    }
                }

                var list = _context.ProductImages.Where(pi => pi.ProductId == product.ProductId).Select(e => new { e.ProductImage1 }).ToList();
                foreach (var image in list)
                {
                    uploadedFiles.Add(image.ProductImage1);
                }


                product.ProductName = input.ProductName;
                product.SupplierId = input.SupplierId;
                product.CategoryId = input.CategoryId;
                product.Describe = input.Describe;
                product.Author = input.Author;
                product.QuantityPerUnit = input.QuantityPerUnit;
                product.UnitPrice = input.UnitPrice;
                product.UnitsInStock = input.UnitsInStock;
                product.UnitsOnOrder = input.UnitsOnOrder;
                product.ReorderLevel = input.ReorderLevel;
                product.Discontinued = input.Discontinued;

                _context.Products.Update(product);
                var result = _context.SaveChanges();
                if (result != null)
                {
                    StatusMessage = $"Đã chỉnh sửa sản phẩm: {product.ProductName}";
                    categories = _context.Categories.ToList();
                    suppliers = _context.Suppliers.ToList();
                    return Page();
                }
                else
                {
                    StatusMessage = $"Lỗi chỉnh sửa sửa sản phẩm không thành công: {product.ProductName}";
                    categories = _context.Categories.ToList();
                    suppliers = _context.Suppliers.ToList();
                    return Page();
                }
            }

            return Page();
        }
    }
}
