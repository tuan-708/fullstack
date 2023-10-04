using api.Model;
using api.Repository;

namespace api.Service
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoryService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public void addCategorie(Category category)
        {
            _categoriesRepository.AddCategory(category);
        }

        public List<Category> GetAllCategories()
        {
            return _categoriesRepository.GetAllCategories();
        }

        public Category GetCategorById(int id)
        {
            return _categoriesRepository.GetCategoryById(id);
        }


        public void deleteCategorieById(int id)
        {
            _categoriesRepository.DeleteCategoryById(id);
        }

        public void updateCategorie(Category category)
        {
            _categoriesRepository.UpdateCategory(category);
        }
    }
}
