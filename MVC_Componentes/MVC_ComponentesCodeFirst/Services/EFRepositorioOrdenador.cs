using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst.App_Data;
using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Services;

public class EFRepositorioOrdenador : IRepositorioOrdenador, IConfiguracionMVC
{

    private readonly DesignTimeComponenteContextFactory factoriaDeContextos = new();
    private readonly ComponentesCodeFirstContext contexto;
    private readonly IComponenteRepositorio _componenteRepositorio;
	public EFRepositorioOrdenador(IConfiguracionMVC config , IComponenteRepositorio componenteRepositorio)
    {
        
        var args = new string[1];

        args[0] = config.CadenaDeConexion;
        contexto = factoriaDeContextos.CreateDbContext(args);
        DbInitializerOrdenadores.Initialize(contexto);
        _componenteRepositorio = componenteRepositorio;
    }
    public Ordenador? GetOrdenador(int Id)
    {
        var ordenador = contexto.Ordenadores!
            .Include(o=>o.Componentes).FirstOrDefault(o=>o.Id == Id);
        
        if (ordenador != null)
        {
            GetPrecioTotal(Id);
            GetCalorTotal(Id);
            contexto.SaveChanges();
        }
        return ordenador;
    }

    public void DeleteOrdenador(int Id)
    {
        Ordenador ordenador = contexto.Ordenadores?.Find(Id)!;
        contexto.Ordenadores?.Remove(ordenador);
        contexto.SaveChanges();
    }

    public void AddOrdenador(Ordenador ordenador)
    {
        var componentes = ordenador.Componentes;
	    Ordenador orde = new()
	    {
		    Propietario = ordenador.Propietario,
	    };
        contexto.Add(orde);

        contexto.SaveChanges();

        int nuevaId = orde.Id;
        if (componentes != null)
	        foreach (var componente in componentes)
	        {
		        var compi = _componenteRepositorio.GetById(componente.Id);
		        compi!.OrdenadorId = nuevaId;
		        contexto.Componentes?.Update(compi);
	        }

        contexto.SaveChanges();
    }

    
    public List<Ordenador>? GetOrdenadorList()
    {
        var ordenadores = contexto.Ordenadores!
            .Include(o => o.Componentes);

        foreach (var ordenadorItem in ordenadores)
        {
            GetOrdenador(ordenadorItem.Id);
        }
        return ordenadores.AsNoTracking().ToList();
    }

    public decimal? GetPrecioTotal(int Id)
    {
        var ordenador = contexto.Ordenadores!.Find(Id);
        if (ordenador != null)
        {
            ordenador.Precio = ordenador.Componentes!.Sum(x => x.Precio);
        }
        return ordenador!.Precio;
    }

    public int? GetCalorTotal(int Id)
    {
        
            var ordenador = contexto.Ordenadores!.Find(Id);
            if (ordenador != null)
            {
                ordenador.CalorTotal = ordenador.Componentes!.Sum(x=>x.Grados) ;
            
                
            }        
            return ordenador!.CalorTotal;
    }

	public void Update(Ordenador? ordenador, int id)
	{
        if (ordenador != null)
        {
            var ordenadorActual = contexto.Ordenadores!.Find(id);

            if (ordenadorActual != null)
            {
	            ordenadorActual.Componentes = ordenador.Componentes;
	            ordenadorActual.CalorTotal = ordenador.CalorTotal;
	            ordenadorActual.Precio = ordenador.Precio;
	            ordenadorActual.PedidoId = ordenador.PedidoId;
	            ordenadorActual.Propietario = ordenador.Propietario;
            }
        }

        contexto.SaveChanges();
	}

	public string CadenaDeConexion { get; set; } = null!;
}