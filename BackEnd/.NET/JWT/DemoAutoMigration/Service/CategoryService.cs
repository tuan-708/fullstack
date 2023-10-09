using DemoAutoMigration.IRepositories;
using DemoAutoMigration.IRepository;
using DemoAutoMigration.IService;
using DemoAutoMigration.Models;

namespace DemoAutoMigration.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository catRepo;

        public CategoryService(ICategoryRepository repository)
        {
            this.catRepo = repository;
        }

        public int Add(Category data)
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public string[] getAllName(string? ids)
        {
            var list = new List<Category>();
            var arr = ids.Split(',').Select(s => s.Trim()).ToArray();
            foreach (var item in arr)
            {
                var i = catRepo.getById(int.Parse(item));
                if(i != null && !i.isDelete)
                {
                    list.Add(i);
                }
            }
            return list.Select(x => x.name).ToArray();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Category data)
        {
            throw new NotImplementedException();
        }
    }
}
