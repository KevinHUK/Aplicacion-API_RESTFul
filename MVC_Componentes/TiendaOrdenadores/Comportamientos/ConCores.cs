using TiendaOrdenadores.Interfaces.Comportamientos;

namespace TiendaOrdenadores.Comportamientos;

public class ConCores : IProcesable
{
    public ConCores(int cores)
    {
        Cores = cores;
    }

    public int Cores { get; }

}