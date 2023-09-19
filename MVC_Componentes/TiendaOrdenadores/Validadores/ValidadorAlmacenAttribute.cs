using System.ComponentModel.DataAnnotations;
using TiendaOrdenadores.Componentes;

namespace TiendaOrdenadores.Validadores;

public class ValidadorAlmacenAttribute : ValidationAttribute
{
    
    public override bool IsValid(object? value)
    {
        var pedidoStock = (ComponenteDecorator?)value;

        return  pedidoStock is { Stock: > 0 };
    }
    
}