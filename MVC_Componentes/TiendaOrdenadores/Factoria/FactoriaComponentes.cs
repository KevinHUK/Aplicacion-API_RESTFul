using TiendaOrdenadores.Componentes;
using TiendaOrdenadores.Factoria.Enumeradores;
using TiendaOrdenadores.Factoria.Interfaces;

namespace TiendaOrdenadores.Factoria;

public class FactoriaComponentes : IComponenteFactoryMethod
{
    public IComponente? DameComponente(TipoComponentes tipo)
    {
        IncialBuilderComponentes build = new();

        return tipo switch
        {
            TipoComponentes._789XCS => build.DameTipoDeComponente(TipoColeccionComponentes.Procesadores, "789XCS",
                                134, 9, 0, 0, 10),

            TipoComponentes._879FH => build.DameTipoDeComponente(TipoColeccionComponentes.Memorizadores, "879FH",
                                100, 0, 512, 0, 10),

            TipoComponentes._789XX => build.DameTipoDeComponente(TipoColeccionComponentes.Guardadores, "789XX",
                                50, 0, 0, 50, 10),

            TipoComponentes._789XCD => build.DameTipoDeComponente(TipoColeccionComponentes.Procesadores, "789XCD",
                                134, 9, 0, 0, 12),

            TipoComponentes._789XCT => build.DameTipoDeComponente(TipoColeccionComponentes.Procesadores, "789XCT",
                                138, 11, 0, 0, 22),

            TipoComponentes._879FHT => build.DameTipoDeComponente(TipoColeccionComponentes.Memorizadores, "879FHT",
                                150, 0, 2000, 0, 24),

            TipoComponentes._879FHL => build.DameTipoDeComponente(TipoColeccionComponentes.Memorizadores, "879FHL",
                                125, 0, 1000, 0, 15),

            TipoComponentes._789XX2 => build.DameTipoDeComponente(TipoColeccionComponentes.Guardadores, "789XX2",
                                90, 0, 0, 1000, 29),

            TipoComponentes._789XX3 => build.DameTipoDeComponente(TipoColeccionComponentes.Guardadores, "789XX3",
                                128, 0, 0, 2000, 39),

            TipoComponentes._797X => build.DameTipoDeComponente(TipoColeccionComponentes.Procesadores, "797X",
                                78, 10, 0, 0, 30),

            TipoComponentes._797X2 => build.DameTipoDeComponente(TipoColeccionComponentes.Procesadores, "797X2",
                                178, 29, 0, 0, 30),

            TipoComponentes._797X3 => build.DameTipoDeComponente(TipoColeccionComponentes.Procesadores, "797X3",
                                278, 34, 0, 0, 60),

            TipoComponentes._788fg => build.DameTipoDeComponente(TipoColeccionComponentes.Guardadores, "788fg",
                                37, 0, 0, 250, 35),

            TipoComponentes._788fg2 => build.DameTipoDeComponente(TipoColeccionComponentes.Guardadores, "788fg2",
                                67, 0, 0, 250, 35),

            TipoComponentes._788fg3 => build.DameTipoDeComponente(TipoColeccionComponentes.Guardadores, "788fg3",
                                97, 0, 0, 250, 35),

            TipoComponentes._1789XCS => build.DameTipoDeComponente(TipoColeccionComponentes.Guardadores, "1789XCS",
                                134, 0, 0, 9000, 10),

            TipoComponentes._1789XCD => build.DameTipoDeComponente(TipoColeccionComponentes.Guardadores, "1789XCD",
                                138, 0, 0, 10000, 11),

            TipoComponentes._1789XCT => build.DameTipoDeComponente(TipoColeccionComponentes.Guardadores, "1789XCT",
                                140, 0, 0, 11000, 22),

            _ => null,
        };
    }
}