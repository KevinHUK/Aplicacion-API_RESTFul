using System.ComponentModel.DataAnnotations;
using TiendaOrdenadores.Pedidos;

namespace TiendaOrdenadores.Validadores;

public class ValidadorPedidosAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var pedido = (Pedido?)value;
        
        return pedido != null && pedido.CalorTotalPedido() > 0 && pedido.PrecioTotalPedido() > 0 ;
    }
    
}