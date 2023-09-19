using TiendaOrdenadores.Componentes;

namespace TiendaOrdenadores.Almacen;

public interface IAlmacen
{
    public void Add(ComponenteDecorator componente);
    public List<ComponenteDecorator> GetComponentes();
}