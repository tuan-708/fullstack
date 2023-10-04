using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BookStore.Pages.Admin.Products.Category
{
    [Authorize(Roles = "Admin")]
    public class UpdateCategoryModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly StoresManagementContext _context;

        public UpdateCategoryModel(IWebHostEnvironment webHostEnvironment, StoresManagementContext context)
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

        public void OnGet(int cid)
        {
            Models.Category c =  _context.Categories.FirstOrDefault(c => c.CategoryId == cid);
            if (c != null)
            {
                InputModel i = new InputModel();
                i.CategoryName = c.CategoryName;
                i.Description = c.Description;
                ViewData["picture"] = c.Picture;

                Input = i;
            }
        }


        public async Task<IActionResult> OnPost(List<IFormFile> postedFiles, InputModel input, int cid)
        {
            Models.Category ca = _context.Categories.FirstOrDefault(c => c.CategoryId == cid);
            if (ca != null)
            {
                Models.Category find = _context.Categories.Where(x => x.CategoryName == input.CategoryName).FirstOrDefault();
                if (find == null)
                {
                    List<string> uploadedFiles = new List<string>();

                    if (postedFiles.Count > 0)
                    {
                        string path = Path.Combine(this._webHostEnvironment.WebRootPath, "uploads");

                        if (ca.Picture != null)
                        {
                            string path1 = Path.Combine(path, ca.Picture);
                            try
                            {
                                if (System.IO.File.Exists(path1))
                                {
                                    System.IO.File.Delete(path1);
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
                                ca.Picture = fileName;
                            }
                        }
                    }

                    ca.CategoryName = input.CategoryName;
                    ca.Description = input.Description;
                    ViewData["picture"] = ca.Picture;

                    _context.Categories.Update(ca);
                    var result = _context.SaveChanges();
                    if (result != null)
                    {
                        StatusMessage = $"Đã chỉnh sửa thể loại: {ca.CategoryName}";
                        Page();
                    }
                    else
                    {
                        StatusMessage = $"Lỗi chỉnh sửa thể loại không thành công: {ca.CategoryName}";
                        Page();
                    }
                }
                else
                {
                    Models.Category c = _context.Categories.FirstOrDefault(c => c.CategoryId == cid);
                    if (c != null)
                    {
                        InputModel i = new InputModel();
                        i.CategoryName = c.CategoryName;
                        i.Description = c.Description;
                        ViewData["picture"] = c.Picture;

                        Input = i;
                    }
                    StatusMessage = $"Lỗi tồn tại thể loại: {ca.CategoryName}";
                }
            }
            return Page();
        }
    }
}
