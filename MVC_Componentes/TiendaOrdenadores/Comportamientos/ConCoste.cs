using TiendaOrdenadores.Interfaces.Comportamientos;

namespace TiendaOrdenadores.Comportamientos;

public class ConCoste : ICoste
{
    public ConCoste(double coste)
    {
        Precio = coste;
    }
    public double Precio { get; }
}