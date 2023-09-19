using MVC_ComponentesCodeFirst.App_Data;
using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Services;

public class FakeRepositorioComponentes : IComponenteRepositorio
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
    public List<Componente> All()
    {
        return componentes;
    }

    public Componente? GetById(int Id)
    {
       
        
	        var componenteEncontrado = componentes.FirstOrDefault(x=>x.Id == Id);
	        return componenteEncontrado;
        
	}

    public void Add(Componente componente)
    {
        var idNueva = componentes.Count;
        componente.Id = idNueva;
        componentes.Add(componente);
    }

    public void Update(Componente componente, int id)
    {
        throw new NotImplementedException();
    }



    public void Delete(int id)
    {
        componentes.RemoveAt(id);
    }


}