using System.ComponentModel.DataAnnotations;
using TiendaOrdenadores.Componentes;
using TiendaOrdenadores.Interfaces;
using TiendaOrdenadores.Validadores;

namespace TiendaOrdenadores;

public class Ordenador : IOrdenador, ICaracteristicasComponenentes
{

    private readonly List<IComponente> _componentes = new();
    private readonly ValidationAttribute _validador = new ValidadorComponentesAttribute();

    public void Add(IComponente nuevoComponente)
    {
        if (_validador.IsValid(nuevoComponente))
        {
            _componentes.Add(nuevoComponente);
        }


    }

    public List<IComponente> DameOrdenador()
    {
        return _componentes;
    }
    public int CalorTotal
    {
        get => _componentes.FindAll((x)
            => x.Calor >= 0).Sum(x => x.Calor);

        set { }
    }

    public double PrecioPorOrdenador
    {
        get => _componentes.FindAll((x)
            => x.Precio >= 0).Sum((x) => x.Precio);
        set { }
    }
}