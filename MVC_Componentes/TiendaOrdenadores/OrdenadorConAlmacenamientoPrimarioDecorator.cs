using System.ComponentModel.DataAnnotations;
using TiendaOrdenadores.Componentes;
using TiendaOrdenadores.Validadores;

namespace TiendaOrdenadores;

public class OrdenadorConAlmacenamientoPrimarioDecorator : Ordenador
{
    private readonly Ordenador? ordenadorInyectado;
    private readonly List<IComponente>? ListaExtraAlmacenamiento;
    private readonly ValidationAttribute validador = new ValidadorOrdenadorAttribute();
    public OrdenadorConAlmacenamientoPrimarioDecorator(Ordenador ordenadorHeredado, List<IComponente> listExtra)
    {
        if (validador.IsValid(ordenadorHeredado))
        {

            ordenadorInyectado = ordenadorHeredado;
            ListaExtraAlmacenamiento = listExtra;
        }

        
        

    }

    public new int CalorTotal
    {
        get
        {
            if (ordenadorInyectado == null) return base.CalorTotal;
            if (ListaExtraAlmacenamiento != null)
                return base.CalorTotal +=
                    ordenadorInyectado.CalorTotal + ListaExtraAlmacenamiento.Sum(p => p.Calor);
            return base.CalorTotal;
        }

        set => throw new NotImplementedException();
    }

    public new double PrecioPorOrdenador
    {
        get
        {
            if (ordenadorInyectado == null) return base.PrecioPorOrdenador;
            if (ListaExtraAlmacenamiento != null)
                return base.PrecioPorOrdenador +=
                    ordenadorInyectado.PrecioPorOrdenador + ListaExtraAlmacenamiento.Sum(p => p.Precio);
            return base.PrecioPorOrdenador;
        }
        set => throw new NotImplementedException();
    }
}