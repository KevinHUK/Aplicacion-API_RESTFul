using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst.App_Data;
using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Services;

public class EFRepositoryComponentes : IComponenteRepositorio, IConfiguracionMVC
{
    private readonly DesignTimeComponenteContextFactory factoriaDeContextos = new();
    private readonly ComponentesCodeFirstContext contexto;

    public EFRepositoryComponentes(IConfiguracionMVC config)
    {
        
        var args = new string[1];
        
         args[0] = config.CadenaDeConexion;
        contexto = factoriaDeContextos.CreateDbContext(args);
       DbInitializerComponentes.Initialize(contexto);
        
    }

    public string CadenaDeConexion {
        get ;
        set;
    } = null!;

    public void Add(Componente componente)
    {
        contexto.Add(componente);
        contexto.Entry(componente).Property(u => u.OrdenadorId).IsModified = false;
        contexto.SaveChanges();

    }

    public  List<Componente> All()
    {

        return contexto.Componentes!.AsNoTracking().ToList();

    }

    public void Delete(int id)
    {
        Componente componente = contexto.Componentes?.Find(id)!;
        contexto.Componentes?.Remove(componente);
        contexto.SaveChanges();

    }

    

    public Componente? GetById(int Id)
    {
        {
            var componenteEncontrado = contexto.Componentes?.Find(Id);
            if (componenteEncontrado != null) return componenteEncontrado;
        }
        return null;
    }

    public void Update(Componente componente, int id)
    {
        var componenteActual = GetById(id);
        if (componenteActual != null)
        {
	        componente.Categoria = componenteActual.Categoria;
	        componente.Cores = componenteActual.Cores;
	        componente.Descripcion = componenteActual.Descripcion;
	        componente.Grados = componenteActual.Grados;
	        componente.OrdenadorId = componenteActual.OrdenadorId;
	        componente.NumeroDeSerie = componenteActual.NumeroDeSerie;
	        componente.Precio = componenteActual.Precio;
	        componente.Megas = componenteActual.Megas;
        }


        contexto.SaveChanges();
    }




   
}