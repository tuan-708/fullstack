using DemoAutoMigration.IRepositories;
using DemoAutoMigration.Models;

namespace DemoAutoMigration.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JobContext context;

        public CategoryRepository(JobContext context)
        {
            this.context = context;
        }

        public int countObject()
        {
            throw new NotImplementedException();
        }

        public int createObject(Category data)
        {
            throw new NotImplementedException();
        }

        public int deleteObject(int id)
        {
            var cat = context.categories.FirstOrDefault(x => 
            x.id == id &&
            x.isDelete == false
            );
            if (cat != null)
            {
                cat.isDelete = true;
                context.categories.Update(cat);
                return context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<Category> getAllObject()
        {
            return context.categories.ToList();
        }

        public Category getById(int id)
        {
            return context.categories.FirstOrDefault(x => x.id == id);
        }

        public int updateObject(Category data)
        {
            throw new NotImplementedException();
        }
    }
}
