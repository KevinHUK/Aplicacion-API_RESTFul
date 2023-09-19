using TiendaOrdenadores.Factoria.Enumeradores;

namespace TiendaOrdenadores.Componentes;

public class ComponenteDecorator : Componente
{
    public ComponenteDecorator(TipoColeccionComponentes tipo, double precio, string numeroDeSerie, int cores, double memoriaRam, double memoriaDisco, int temperatura, int stock) : base(tipo, precio, numeroDeSerie, cores, memoriaRam, memoriaDisco, temperatura)
    {
        Stock = stock;
    }

    public int Stock
    {
        get;
    }
}