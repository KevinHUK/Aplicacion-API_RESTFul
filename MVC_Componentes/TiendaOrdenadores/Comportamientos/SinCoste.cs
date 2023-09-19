using TiendaOrdenadores.Interfaces.Comportamientos;

namespace TiendaOrdenadores.Comportamientos;

public class SinCoste : ICoste
{
    public double Precio { get; } = 0;
}