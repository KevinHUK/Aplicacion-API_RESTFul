using TiendaOrdenadores.Factoria.Enumeradores;
using TiendaOrdenadores.Interfaces.Comportamientos;

namespace TiendaOrdenadores.Componentes;

public interface IComponente : ICoste, ICalorable, INSerializable
{
    TipoColeccionComponentes Tipo { get; }
}