using TiendaOrdenadores.Componentes;

namespace TiendaOrdenadores.Almacen;

public class Almacen :   IAlmacen
{
    private readonly List<ComponenteDecorator> _componentes = new();

    public void Add(ComponenteDecorator componente)
    {
        _componentes.Add(componente);
        
    }

    public List<ComponenteDecorator> GetComponentes() => _componentes;

}