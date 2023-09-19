using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst.App_Data;
using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Services;

public class EFRepositoryPedidos: IPedidoRepositorio
{
    private readonly DesignTimeComponenteContextFactory factoriaDeContextos = new();
    private readonly ComponentesCodeFirstContext contexto;
    public EFRepositoryPedidos(IConfiguracionMVC config)
    {
        var args = new string[1];

        args[0] = config.CadenaDeConexion;
        contexto = factoriaDeContextos.CreateDbContext(args);
        DbInitializerPedidos.Initialize(contexto);
    }
    public Pedido? getPedidoById(int Id)
    {
        var pedido = contexto.Pedidos!
		        .Include(p => p.Ordenadores)!.
            ThenInclude(o=>o.Componentes)
            .FirstOrDefault(p => p.Id == Id)
            ;

        if (pedido != null)
        {
            GetPrecioTotal(Id);
            GetCalorTotal(Id);
            contexto.SaveChanges();
        }
        return pedido;

    }


    public decimal? GetPrecioTotal(int Id)
    {
        var pedido = contexto.Pedidos!.Find(Id);
        if (pedido != null)
        {
            pedido.Precio = pedido.Ordenadores!.Sum(x => x.Precio);
        }
        return pedido!.Precio;
    }

    public int? GetCalorTotal(int Id)
    {
        var pedido = contexto.Pedidos!.Find(Id);
        if (pedido != null)
        {
            pedido.Temperatura = pedido.Ordenadores!.Sum(x => x.CalorTotal);
        }
        return pedido!.Temperatura;
    }

    public void Add(Pedido pedido)
    {
        contexto.Add(pedido);
        contexto.SaveChanges();
    }

    public List<Pedido> GetAllPedidos()
    {
        var pedidos = contexto.Pedidos!
                .Include(p => p.Ordenadores)!.
                ThenInclude(o => o.Componentes);

        if (pedidos != null)
        {
            foreach (var pedido in pedidos)
            {
                getPedidoById(pedido.Id);
            }

            
        }
        return pedidos!.AsNoTracking().ToList();
    }

    public void Update(Pedido? pedido, int id)
    {
	    var pedidoActual = contexto.Pedidos!.Find(id);


	    if (pedidoActual != null)
	    {
		    pedidoActual.Nombre = pedido!.Nombre;
		    pedidoActual.Ordenadores = pedido.Ordenadores;
		    pedidoActual.Temperatura = pedido.Temperatura;
		    pedidoActual.Precio = pedido.Precio;
		    pedidoActual.Cantidad = pedido.Cantidad;
	    }

	    contexto.SaveChanges();
    }

    public void Delete(int? id)
    {
        var pedido = contexto.Pedidos?.Find(id);
        if (pedido != null) contexto.Pedidos?.Remove(pedido);
        contexto.SaveChanges();
    }
}