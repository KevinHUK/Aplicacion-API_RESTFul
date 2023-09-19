using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.App_Data;

public static class DbInitializerOrdenadores
{
    public static void Initialize(ComponentesCodeFirstContext contexto)
    {
        contexto.Database.EnsureCreated();
        if (contexto.Ordenadores != null && contexto.Ordenadores.Any())
        {
            return;
        }

        var ordenadores = new []
        {
            new Ordenador
            {
                Propietario = "Andres",
                Componentes = new[]
                {
                    contexto.Componentes!.Single(x=>x.NumeroDeSerie=="879FH-T"),
                    contexto.Componentes!.Single(x => x.NumeroDeSerie == "789-XX-3"),
                    contexto.Componentes!.Single(x => x.NumeroDeSerie == "797-X3"),

                }
            },
            new Ordenador
            {
                Propietario = "Maria",
                Componentes = new[]
                {
                    contexto.Componentes!.Single(x=>x.NumeroDeSerie=="789-XCS"),
                    contexto.Componentes!.Single(x => x.NumeroDeSerie == "879FH"),
                    contexto.Componentes!.Single(x => x.NumeroDeSerie == "789-XX"),

                }
            }
        };
        contexto.Ordenadores!.AddRange(ordenadores);
        contexto.SaveChanges();
    }
}
       

            