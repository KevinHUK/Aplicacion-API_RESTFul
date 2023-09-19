namespace MVC_ComponentesCodeFirst.Services;

public interface IRepositorio<T>
{
    IEnumerable<T> GetAll();
    T GetById(object id);
    void Insert(T obj);
    void Update(T obj, int id);
    void Delete(object id);
    void Save();
}