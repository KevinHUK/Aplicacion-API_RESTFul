using MVC_ComponentesDatabaseFirst.Models;

namespace MVC_ComponentesDatabaseFirst.Services;

public class EFRepository : IComponenteRepositorio
{
    private readonly DesignTimeComponenteContextFactory factoriaDeContextos = new();
    private readonly ComponentesDatabaseFirstContext contexto;

    public EFRepository()
    {
        
        string[] args = new string[1];
        contexto = factoriaDeContextos.CreateDbContext(args);
    }
    public void Add(Componente componente)
    {
        contexto.Add(componente);
        contexto.SaveChanges();

    }

    public List<Componente> All()
    {
        return contexto.Componentes!.ToList();
    }

    public void Delete(int id)
    {
        Componente componente = contexto.Componentes!.Find(id)!;
        contexto.Componentes.Remove(componente);

    }

    public Componente? GetById(int Id)
    {
        {
            var componenteEncontrado = contexto.Componentes!.Find(Id);
            if (componenteEncontrado != null) return componenteEncontrado;
        }
        return null;
    }

    public void Update(Componente componente)
    {
        Delete(componente.ComponenteId);
        Add(componente);
    }

   


}