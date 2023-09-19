using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst.App_Data;
using Polly;


namespace MVC_ComponentesCodeFirst.Services;

public class RepositorioGenerico<T> : IRepositorio<T> where T : class
{

    protected ComponentesCodeFirstContext _context = null;

    protected DbSet<T> table = null;

    public RepositorioGenerico()
    {
        this._context = new ComponentesCodeFirstContext(new DbContextOptions<ComponentesCodeFirstContext>());
        table = _context.Set<T>();
    }
    public IEnumerable<T> GetAll()
    {
     
        return table.ToList();
    }

    public T GetById(object id)
    {
        return table.Find(id);
    }

    public void Insert(T obj)
    {
        table.Add(obj);
    }

    public void Update(T obj, int id)
    {
     
        table.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
    }

    public void Delete(object id)
    {
        T existing = table.Find(id);
        table.Remove(existing);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}