using TiendaOrdenadores.Factoria.Enumeradores;

namespace TiendaOrdenadores.Componentes;

public class Componente : IComponente
{
    public TipoColeccionComponentes Tipo { get; }
    public int Cores { get; }
    public double MemoriaRam { get; }
    public double MemoriaDisco { get; }

    public Componente(TipoColeccionComponentes tipo, double precio, string numeroDeSerie, int cores, double memoriaRam, double memoriaDisco, int temperatura)
    {
        Tipo = tipo;
        Precio = precio;
        NumeroDeSerie = numeroDeSerie;
        Cores = cores;
        MemoriaRam = memoriaRam;
        MemoriaDisco = memoriaDisco;
        Calor = temperatura;
    }

    public double Precio
    {
        get;
    }
    public string NumeroDeSerie
    {
        get;

    }
    public int Calor { get; }

}