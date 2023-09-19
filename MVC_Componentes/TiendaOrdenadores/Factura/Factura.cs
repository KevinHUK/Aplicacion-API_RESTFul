using System.ComponentModel.DataAnnotations;
using TiendaOrdenadores.Pedidos;
using TiendaOrdenadores.Validadores;

namespace TiendaOrdenadores.Factura;

public class Factura : IFactura
{
    private readonly List<IPedido> _pedido = new ();

    private readonly ValidationAttribute _validador = new ValidadorPedidosAttribute();
    public void Add(IPedido pedido)
    {
        if (_validador.IsValid(pedido))
        {
            _pedido.Add(pedido);
        }
    }

    public List<IPedido> DameFactura() => _pedido;


    public double GetFacturacion() => _pedido.Sum(x=>x.PrecioTotalPedido());
    
    }