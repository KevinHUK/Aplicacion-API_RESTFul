using TiendaOrdenadores.Componentes;
using TiendaOrdenadores.Factoria.Enumeradores;

namespace TiendaOrdenadores.Factoria.Interfaces;

public interface IComponenteBuilder
{
    IComponente? DameTipoDeComponente(TipoColeccionComponentes tipoComponentes,
         string numSerie, double coste, int cores, int memoriaRam, int memoriaDisco, int temperatura);
}