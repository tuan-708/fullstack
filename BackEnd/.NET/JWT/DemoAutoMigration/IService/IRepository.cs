namespace DemoAutoMigration.IService
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public int Update(T data);
        public int Add(T data);
        public int DeleteById(int id);
    }
}
