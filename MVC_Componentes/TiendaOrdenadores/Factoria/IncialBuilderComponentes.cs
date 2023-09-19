using System.ComponentModel.DataAnnotations;
using TiendaOrdenadores.Componentes;
using TiendaOrdenadores.Comportamientos;
using TiendaOrdenadores.Factoria.Enumeradores;
using TiendaOrdenadores.Factoria.Interfaces;
using TiendaOrdenadores.Interfaces.Comportamientos;
using TiendaOrdenadores.Validadores;

namespace TiendaOrdenadores.Factoria;

public class IncialBuilderComponentes : IComponenteBuilder
{
    public IComponente? DameTipoDeComponente(TipoColeccionComponentes tipoComponentes, string numSerie, double coste, int cores, int memoriaRam, int memoriaDisco, int temperatura)
    {
        INSerializable nSerie;


        if (string.IsNullOrEmpty(numSerie))
        {
            nSerie = new SinSerializar();
        }
        else
        {
            nSerie = new Serializable(numSerie);
        }

        ICoste costeComponente;

        if (coste <= 0)
        {
            costeComponente = new SinCoste();
        }
        else
        {
            costeComponente = new ConCoste(coste);
        }

        ICalorable temperaturaComponente;

        if (temperatura <= 0)
        {
            temperaturaComponente = new SinCalor();
        }
        else
        {
            temperaturaComponente = new ConCalor(temperatura);
        }

        IProcesable coresComp;

        if (cores <= 0)
        {
            coresComp = new SinCores();
        }
        else
        {
            coresComp = new ConCores(cores);
        }


        IAlmacenamiento memoriaRamComponente;

        if (memoriaRam <= 0)
        {
            memoriaRamComponente = new SinAlmacenamiento();
        }
        else { memoriaRamComponente = new ConAlmacenamiento(memoriaRam); }


        IAlmacenamiento memoriaDiscoComponente;
        if (memoriaDisco <= 0)
        {
            memoriaDiscoComponente = new SinAlmacenamiento();
        }
        else
        {
            memoriaDiscoComponente = new ConAlmacenamiento(memoriaDisco);
        }


        ValidationAttribute validadorComponente = new ValidadorComponentesAttribute();
        Componente componente = new(tipoComponentes, costeComponente.Precio, nSerie.NumeroDeSerie, coresComp.Cores,
            memoriaRamComponente.Almacenamiento, memoriaDiscoComponente.Almacenamiento, temperaturaComponente.Calor);
        if (validadorComponente.IsValid(componente))
        {

            return componente;
        }
        else
        {
            return null;
        }


    }


}