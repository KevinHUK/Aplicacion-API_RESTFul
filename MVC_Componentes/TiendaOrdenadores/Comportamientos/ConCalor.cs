using TiendaOrdenadores.Interfaces.Comportamientos;

namespace TiendaOrdenadores.Comportamientos;

public class ConCalor : ICalorable
{
    public ConCalor(int temperatura)
    {
        Calor = temperatura;
    }
    public int Calor { get; }
}