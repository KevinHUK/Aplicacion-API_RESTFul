using TiendaOrdenadores.Interfaces.Comportamientos;

namespace TiendaOrdenadores.Comportamientos;

public class SinSerializar : INSerializable
{
    public string NumeroDeSerie { get; } = String.Empty;
}