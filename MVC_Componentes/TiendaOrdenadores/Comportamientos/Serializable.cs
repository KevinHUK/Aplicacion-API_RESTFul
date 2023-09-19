using TiendaOrdenadores.Interfaces.Comportamientos;

namespace TiendaOrdenadores.Comportamientos;

public class Serializable : INSerializable
{
    public Serializable(string numeroDeSerie)
    {
        NumeroDeSerie = numeroDeSerie;
    }
    public string NumeroDeSerie { get; }
}