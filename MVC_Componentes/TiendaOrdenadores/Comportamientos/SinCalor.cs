using TiendaOrdenadores.Interfaces.Comportamientos;

namespace TiendaOrdenadores.Comportamientos;

public class SinCalor : ICalorable
{
    public int Calor { get; } = 0;
}