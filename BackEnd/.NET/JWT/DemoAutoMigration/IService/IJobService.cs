using DemoAutoMigration.Models;

namespace DemoAutoMigration.IService
{
    public interface IJobService : IRepository<Job>
    {
        public List<Job> findJobByName(string? input);
    }
}
