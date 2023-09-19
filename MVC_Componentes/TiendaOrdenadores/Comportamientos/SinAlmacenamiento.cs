using TiendaOrdenadores.Interfaces.Comportamientos;

namespace TiendaOrdenadores.Comportamientos;

public class SinAlmacenamiento : IAlmacenamiento
{
    public int Almacenamiento { get; } = 0;
}