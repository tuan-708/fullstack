using api.Model;
using api.Repository;
using api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("/api/categories")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<ResponseObject> Get()
        {
            var items = _categoryService.GetAllCategories();

            return Ok(new ResponseObject("oke", "Query successfully!", items.ToList(), items.Count));
        }

        [HttpGet("{id}")]
        public ActionResult<ResponseObject> getCategoryById(int id)
        {
            var item = _categoryService.GetCategorById(id);
            if (item != null) {
                return Ok(new ResponseObject("oke", "Query successfully", item, 1));
            }
            else
            {
                return NotFound(new ResponseObject("false", "Not Found", item, 1));
            }

        }

        [HttpPost("")]
        public ActionResult<ResponseObject> addCategory(string CategoryName, string Description)
        {
            Category ca = new Category();
            ca.CategoryName = CategoryName;
            ca.Description = Description;
            ca.Picture = null;
            _categoryService.addCategorie(ca);
            return Ok(new ResponseObject("oke", "Query successfully", 1, 1));
        }

        [HttpDelete("{id}")]
        public ActionResult<ResponseObject> deleteCategoryById(int id)
        {
            try
            {
                _categoryService.deleteCategorieById(id);
                return Ok(new ResponseObject("oke", "Query successfully", "", 0));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<ResponseObject> updateCategory(int CategoryId, string CategoryName, string Description)
        {
            try
            {
                Category ca = new Category();
                ca.CategoryId = CategoryId;
                ca.CategoryName = CategoryName;
                ca.Description = Description;

                _categoryService.updateCategorie(ca);
                return Ok(new ResponseObject("oke", "Query successfully", ca.CategoryId, 0));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
