using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.App_Data;

public static class DbInitializerPedidos
{
    public static void Initialize(ComponentesCodeFirstContext contexto)
    {
        contexto.Database.EnsureCreated();
        if (contexto.Pedidos != null && contexto.Pedidos.Any())
        {
            return;
        }

        var pedidos = new[]
        {
            new Pedido
            {
                Nombre = "Pedido A",
                Ordenadores = new[]
                {
                    
                    contexto.Ordenadores!.FirstOrDefault(o => o.Propietario == "Andres"),
                    contexto.Ordenadores!.FirstOrDefault(o => o.Propietario == "Maria"),

				}!
            }
        };
        contexto.Pedidos!.AddRange(pedidos);
        contexto.SaveChanges();
    }
}