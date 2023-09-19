using TiendaOrdenadores.Pedidos;

namespace TiendaOrdenadores.Factura;

public interface IFactura
{
    public void Add(IPedido pedido);
    public List<IPedido> DameFactura();

    public double GetFacturacion();
}