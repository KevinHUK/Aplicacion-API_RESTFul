using MVC_ComponentesDatabaseFirst.Models;

namespace MVC_ComponentesDatabaseFirst.Services;

public class FakeRepositorioComponentes : IComponenteRepositorio
{

    private readonly List<Componente> componentes = new();

    public FakeRepositorioComponentes()
    {
        componentes.Add(new Componente()
        {
            ComponenteId = 1,
            Categoria = 0,
            Descripcion = "Procesador Intel i7",
            NumeroDeSerie = "789-XCS",
            Precio = 134,
            Cores = 9,
            Grados = 10,
            Megas = 0
        });
        componentes.Add(new Componente()
        {
            ComponenteId = 2,
            Categoria = 0,
            Descripcion = "Procesador Intel i7",
            NumeroDeSerie = "789-XCD",
            Precio = 138,
            Cores = 10,
            Grados = 12,
            Megas = 0
        });
        componentes.Add(new Componente()
        {
            ComponenteId = 3,
            Categoria = 0,
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

    public Componente GetById(int Id)
    {
        return componentes.First(x => x.ComponenteId == Id);
    }

    public void Add(Componente componente)
    {
        var idNueva = componentes.Count;
        componente.ComponenteId = idNueva;
        componentes.Add(componente);
    }

    public void Update(Componente componente)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        componentes.RemoveAt(id);
    }
}