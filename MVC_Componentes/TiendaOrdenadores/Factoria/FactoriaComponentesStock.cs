using TiendaOrdenadores.Componentes;
using TiendaOrdenadores.Factoria.Enumeradores;
using TiendaOrdenadores.Factoria.Interfaces;

namespace TiendaOrdenadores.Factoria;

public class FactoriaComponentesStock : IComponenteFactoryMethod
{
    public IComponente? DameComponente(TipoComponentes tipo)
    {
        
        return tipo switch
        {
            TipoComponentes._789XCS => new ComponenteDecorator(TipoColeccionComponentes.Procesadores, 134,
                                "789XCS", 9, 0, 0, 10, 1),

            TipoComponentes._879FH => new ComponenteDecorator(TipoColeccionComponentes.Memorizadores, 100,
                                "879FH", 0, 512, 0, 10, 2),

            TipoComponentes._789XX => new ComponenteDecorator(TipoColeccionComponentes.Guardadores, 50,
                                "789XX", 0, 0, 500, 10, 1),

            TipoComponentes._789XCD => new ComponenteDecorator(TipoColeccionComponentes.Procesadores, 138,
                                "789XCD", 134, 9, 0, 12, 1),

            TipoComponentes._789XCT => new ComponenteDecorator(TipoColeccionComponentes.Procesadores, 138,
                                "789XCT", 11, 0, 0, 22, 2),

            TipoComponentes._879FHT => new ComponenteDecorator(TipoColeccionComponentes.Memorizadores, 150, 
                                "879FHT", 0, 2000, 0, 24, 1),

            TipoComponentes._879FHL => new ComponenteDecorator(TipoColeccionComponentes.Memorizadores, 125, 
                                "879FHL", 0, 1000, 0, 15, 1),

            TipoComponentes._789XX2 => new ComponenteDecorator(TipoColeccionComponentes.Guardadores, 90, 
                                "789XX2", 0, 0, 1000, 29, 2),

            TipoComponentes._789XX3 => new ComponenteDecorator(TipoColeccionComponentes.Guardadores, 128, 
                                "789XX3", 0, 0, 2000, 39,1),

            TipoComponentes._797X => new ComponenteDecorator(TipoColeccionComponentes.Procesadores, 78, 
                                "797X", 10, 0, 0, 30,1),

            TipoComponentes._797X2 => new ComponenteDecorator(TipoColeccionComponentes.Procesadores, 178, 
                                "797X2", 29, 0, 0, 30,2),

            TipoComponentes._797X3 => new ComponenteDecorator(TipoColeccionComponentes.Procesadores, 278, 
                                "797X3", 34, 0, 0, 60,1),

            TipoComponentes._788fg => new ComponenteDecorator(TipoColeccionComponentes.Guardadores, 37, 
                                "788fg", 0, 0, 250, 35,1),

            TipoComponentes._788fg2 => new ComponenteDecorator(TipoColeccionComponentes.Guardadores, 67, 
                                "788fg2", 0, 0, 250, 35,1),

            TipoComponentes._788fg3 => new ComponenteDecorator(TipoColeccionComponentes.Guardadores, 97, 
                                "788fg3", 0, 0, 250, 35,1),

            TipoComponentes._1789XCS => new ComponenteDecorator(TipoColeccionComponentes.Guardadores, 134, 
                                "1789XCS", 0, 0, 9000, 10,1),

            TipoComponentes._1789XCD => new ComponenteDecorator(TipoColeccionComponentes.Guardadores, 138,
                                "1789XCD", 0, 0, 10000, 11,1),

            TipoComponentes._1789XCT => new ComponenteDecorator(TipoColeccionComponentes.Guardadores, 140,
                                "1789XCT", 0, 0, 11000, 22,0),
            _ => null,
        };

    }
}