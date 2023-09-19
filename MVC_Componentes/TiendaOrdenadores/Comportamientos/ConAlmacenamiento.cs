using TiendaOrdenadores.Interfaces.Comportamientos;

namespace TiendaOrdenadores.Comportamientos;

public class ConAlmacenamiento : IAlmacenamiento
{
    public ConAlmacenamiento(int megas)
    {
        Almacenamiento = megas;
    }
    public int Almacenamiento { get; }
}