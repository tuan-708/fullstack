using DemoAutoMigration.Models;

namespace DemoAutoMigration.IRepository
{
    public interface IRepository<T>
    {
        public List<T> getAllObject();
        public T getById(int id);
        public int createObject(T data);
        public int updateObject(T data);
        public int deleteObject(int id);
        public int countObject();
    }
}
