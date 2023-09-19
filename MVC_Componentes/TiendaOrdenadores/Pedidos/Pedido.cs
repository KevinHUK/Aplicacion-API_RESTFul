using System.ComponentModel.DataAnnotations;
using TiendaOrdenadores.Validadores;

namespace TiendaOrdenadores.Pedidos;

public class Pedido : IPedido
{
    private readonly Dictionary<Ordenador, int> _coleccionDeOrdenadores = new();
    private readonly ValidationAttribute _validador = new ValidadorOrdenadorAttribute();
    public void AddPedido(Ordenador ordenador)
    {
        if (_validador.IsValid(ordenador) || ordenador.GetType() == typeof(OrdenadorConAlmacenamientoPrimarioDecorator))
        {
            if (!_coleccionDeOrdenadores.ContainsKey(ordenador))
            {
                _coleccionDeOrdenadores.Add(key: ordenador, 1);

            }
            else
            {
                _coleccionDeOrdenadores[ordenador]++;
            }
        }


    }


    public override bool Equals(Object? obj)
    {
        var calor = 0.0;
        var precio = 0.0;
        var ordenador = (Ordenador?)obj;
        foreach (var x in _coleccionDeOrdenadores.Keys)
        {
            calor = x.CalorTotal;
            precio = x.PrecioPorOrdenador;
        }



        return ordenador != null &&
               calor.Equals(ordenador.CalorTotal) &&
               precio.Equals(ordenador.PrecioPorOrdenador);
    }

    public override int GetHashCode()
    {
        return _coleccionDeOrdenadores.GetHashCode();
    }


    public int CalorTotalPedido()
    {

        var ordenadoresDistintos = _coleccionDeOrdenadores.Distinct();
        int calorTotalDelPedido = 0;
        foreach (var ordenador in from key in ordenadoresDistintos
                                  let ordenador = key.Key
                                  select ordenador)
        {
            if (ordenador.GetType() == typeof(OrdenadorConAlmacenamientoPrimarioDecorator))
            {

                calorTotalDelPedido += ((OrdenadorConAlmacenamientoPrimarioDecorator)ordenador).CalorTotal;
            }
            else
            {
                calorTotalDelPedido += ordenador.CalorTotal;
            }
        }

        return calorTotalDelPedido;

    }




    public double PrecioTotalPedido()
    {
        var ordenadoresDistintos = _coleccionDeOrdenadores.Distinct();
        var precioTotalPedido = 0.0;
        foreach (var ordenador in from key in ordenadoresDistintos
                                  let ordenador = key.Key
                                  select ordenador)
        {
            if (ordenador.GetType() == typeof(OrdenadorConAlmacenamientoPrimarioDecorator))
                precioTotalPedido += ((OrdenadorConAlmacenamientoPrimarioDecorator)ordenador).PrecioPorOrdenador;

            else
            {
                precioTotalPedido += ordenador.PrecioPorOrdenador;
            }
        }

        return precioTotalPedido;

    }

    public Dictionary<Ordenador, int> GetPedidos() => _coleccionDeOrdenadores;



}