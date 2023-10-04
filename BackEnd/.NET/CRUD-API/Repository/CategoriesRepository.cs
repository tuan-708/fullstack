using api.Model;
using api.Service;
using System.Diagnostics.Metrics;

namespace api.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly NorthWindContext _context;

        public CategoriesRepository(NorthWindContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public void AddCategory(Category category)
        {
            Category ca = _context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (ca == null)
            {
                var a = _context.Categories.Add(category);
                _context.SaveChanges();
            }
       
        }

        public void DeleteCategoryById(int id)
        {
             Category ca =  _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (ca != null)
            {
                _context.Categories.Remove(ca);
                _context.SaveChanges();
            }

        }

        public void UpdateCategory(Category category)
        {
            Category a = _context.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (a != null)
            {   
                a.CategoryName = category.CategoryName;
                a.Description = category.Description;
                _context.SaveChanges();
            }
        }
    }
}
