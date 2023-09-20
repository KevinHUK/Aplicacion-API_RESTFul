using MVC_ComponentesCodeFirst.App_Data;
using MVC_ComponentesCodeFirst.Models;
using Polly;

namespace MVC_ComponentesCodeFirst.Services;

public class FakeRepositorioComponentes : IRepositorio<Componente>
{

    private readonly List<Componente> componentes = new();

    public FakeRepositorioComponentes()
    {
        componentes.Add(new Componente()
        {
            
            Categoria = CategoriasComponentes.Procesador,
            Descripcion = "Procesador Intel i7",
            NumeroDeSerie = "789-XCS",
            Precio = 134,
            Cores = 9,
            Grados = 10,
            Megas = 0
        });
        componentes.Add(new Componente()
        {
            
            Categoria = CategoriasComponentes.Procesador,
            Descripcion = "Procesador Intel i7",
            NumeroDeSerie = "789-XCD",
            Precio = 138,
            Cores = 10,
            Grados = 12,
            Megas = 0
        });
        componentes.Add(new Componente()
        {
            
            Categoria = CategoriasComponentes.Procesador,
            Descripcion = "Procesador Intel i7",
            NumeroDeSerie = "789-XCT",
            Precio = 138,
            Cores = 11,
            Grados = 12,
            Megas = 0
        });
    }


    public IEnumerable<Componente> GetAll()
    {
        return componentes;
    }

    public Componente GetById(object id)
    {
        var componenteEncontrado = componentes.FirstOrDefault(x => x.Id ==(int) id);
        
        return componenteEncontrado;
    }

    public void Insert(Componente obj)
    {
        var idNueva = componentes.Count;
        obj.Id = idNueva;
        componentes.Add(obj);
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
        componentes.Add(componente);

    }

    public void Delete(object id)
    {
        componentes.RemoveAt((int)id);
    }

    public void Save()
    {
        Save();
    }


   


}