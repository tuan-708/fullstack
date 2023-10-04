using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;


namespace BookStore.Pages.Admin.Products.Category
{
    [Authorize(Roles = "Admin")]
    public class NewCategoryModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly StoresManagementContext _context;

        public NewCategoryModel(IWebHostEnvironment webHostEnvironment, StoresManagementContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Display(Name = "Choose the cover photo of your book")]
            [Required]
            public IFormFile CoverPhoto { get; set; }
            public string CoverImageUrl { get; set; }

            [Display(Name = "Tên thể loại")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài {2} đến {1} ký tự")]
            public string CategoryName { get; set; } = null!;

            [Display(Name = "Miêu tả")]
            public string? Description { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(List<IFormFile> postedFiles, InputModel input)
        {
            Models.Category find = _context.Categories.Where(x => x.CategoryName == input.CategoryName).FirstOrDefault();
            if (find == null)
            {
                string path = Path.Combine(this._webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                Models.Category c = new Models.Category();

                List<string> uploadedFiles = new List<string>();

                if (postedFiles.Count > 0)
                {
                    foreach (IFormFile postedFile in postedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        var name = fileName.Split(".");
                        fileName = Guid.NewGuid().ToString() + "." + name[1];
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                            c.Picture = fileName;
                        }
                    }
                }

                c.CategoryName = input.CategoryName;
                c.Description = input.Description;


                _context.Categories.Add(c);
                var result = _context.SaveChanges();
                if (result != null)
                {
                    StatusMessage = $"Đã Thêm thể loại: {input.CategoryName}";
                    return Page();
                }
                else
                {
                    StatusMessage = $"Lỗi thêm thể loại không thành công: {input.CategoryName}";
                    return Page();
                }
            }
            else
            {
                StatusMessage = $"Lỗi thể loại đã tồn tại. {input.CategoryName}";
                return Page();
            }
        }
    }
}
