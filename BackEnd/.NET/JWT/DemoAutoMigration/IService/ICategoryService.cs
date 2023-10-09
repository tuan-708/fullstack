using DemoAutoMigration.Models;

namespace DemoAutoMigration.IService
{
    public interface ICategoryService : IRepository<Category>
    {
        public string[] getAllName(string? ids);
    }
}
