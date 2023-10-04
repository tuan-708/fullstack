using api.Model;

namespace api.Service
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();

        public Category GetCategorById(int id);

        public void addCategorie(Category category);

        public void deleteCategorieById(int id);

        public void updateCategorie(Category category);
    }
}
