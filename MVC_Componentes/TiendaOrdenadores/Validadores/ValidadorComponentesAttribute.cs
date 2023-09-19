using System.ComponentModel.DataAnnotations;
using TiendaOrdenadores.Componentes;

namespace TiendaOrdenadores.Validadores;

public class ValidadorComponentesAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var componente = (Componente?)value;


        return componente != null && componente.NumeroDeSerie != "" && componente is { Precio: > 0, Calor: >= 0, Cores: >= 0, MemoriaDisco: >= 0, MemoriaRam: >= 0 };
    }
}