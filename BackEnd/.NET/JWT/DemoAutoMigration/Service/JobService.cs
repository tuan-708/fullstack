using DemoAutoMigration.IRepository;
using DemoAutoMigration.IService;
using DemoAutoMigration.Models;

namespace DemoAutoMigration.Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepository repository;

        public JobService(IJobRepository repository)
        {
            this.repository = repository;
        }

        public int Add(Job data)
        {
            return repository.createObject(data);
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Job> findJobByName(string? input)
        {
            throw new NotImplementedException();
        }

        public List<Job> GetAll()
        {
            return repository.getAllObject();
        }

        public Job GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Job data)
        {
            throw new NotImplementedException();
        }
    }
}
