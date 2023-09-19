using MVC_ComponentesCodeFirst.Models;
using Newtonsoft.Json;

namespace MVC_ComponentesCodeFirst.Services;

public class APIPedidosRepository : IPedidoRepositorio
{
    HttpClient _httpClient = null;
    private const string urlBase = "https://tiendaordenadoreswebapi20230915115409.azurewebsites.net/api/Pedidos";

    public APIPedidosRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public Pedido? getPedidoById(int Id)
    {
        throw new NotImplementedException();
    }

    public decimal? GetPrecioTotal(int Id)
    {
        throw new NotImplementedException();
    }

    public int? GetCalorTotal(int Id)
    {
        throw new NotImplementedException();
    }

    public void Update(Pedido? pedido, int id)
    {
        throw new NotImplementedException();
    }

    public void Add(Pedido pedido)
    {
        throw new NotImplementedException();
    }

    public void Delete(int? id)
    {
        throw new NotImplementedException();
    }

    public List<Pedido>? GetAllPedidos()
    {
        var callResponse = _httpClient.GetAsync(urlBase).Result;
        
        var response = callResponse.Content.ReadAsStringAsync().Result;
        var pedidos = JsonConvert.DeserializeObject<List<Pedido>>(response);
        return pedidos;
    }
}