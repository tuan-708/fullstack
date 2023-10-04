using api.Model;

namespace api.Repository
{
    public interface ICategoriesRepository
    {
        public List<Category> GetAllCategories();

        public Category GetCategoryById(int id);

        public void AddCategory(Category category);

        public void DeleteCategoryById(int id);

        public void UpdateCategory(Category category);


    }
}
