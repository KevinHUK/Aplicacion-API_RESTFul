using TiendaOrdenadores.Componentes;

namespace TiendaOrdenadores.Interfaces;

public interface IOrdenador
{
    public void Add(IComponente nuevoComponente);
}