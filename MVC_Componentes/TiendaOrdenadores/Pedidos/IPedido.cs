namespace TiendaOrdenadores.Pedidos;

public interface IPedido 
{
    public void AddPedido(Ordenador ordenador);
    public int CalorTotalPedido();
    public double PrecioTotalPedido();

    public Dictionary<Ordenador, int> GetPedidos();
}