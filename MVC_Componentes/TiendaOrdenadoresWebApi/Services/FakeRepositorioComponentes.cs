using TiendaOrdenadoresWebApi.App_Data;
using TiendaOrdenadoresWebApi.Models;

namespace TiendaOrdenadoresWebApi.Services;

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

  

    public void Add(Componente componente)
    {
        var idNueva = componentes.Count;
        componente.Id = idNueva;
        componentes.Add(componente);
    }



    public void Delete(int id)
    {
        componentes.RemoveAt(id);
    }

	public IEnumerable<Componente> GetAll()
	{
        return componentes;
	}

	public Componente? Get(int id)
	{

        var componenteEncontrado = componentes.FirstOrDefault(x => x.Id == id);
        return componenteEncontrado;
    }

	public void Create(Componente item)
	{
        var idNueva = componentes.Count;
        item.Id = idNueva;
        componentes.Add(item);
    }

	public void Update(Componente item)
	{
		throw new NotImplementedException();
	}
}