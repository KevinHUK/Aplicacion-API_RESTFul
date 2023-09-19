using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Services;

public interface IPedidoRepositorio
{
    Pedido? getPedidoById(int Id);

    decimal? GetPrecioTotal (int Id);
    int? GetCalorTotal (int Id);

    void Update(Pedido? pedido, int id);
    void Add (Pedido pedido);

    void Delete (int? id);
    List<Pedido>? GetAllPedidos();
}