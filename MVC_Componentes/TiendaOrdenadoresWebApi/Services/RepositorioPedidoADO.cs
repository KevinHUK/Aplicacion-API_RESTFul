using Microsoft.Data.SqlClient;
using TiendaOrdenadoresWebApi.App_Data;
using TiendaOrdenadoresWebApi.Models;

namespace TiendaOrdenadoresWebApi.Services;

public class RepositorioPedidoADO : IRepositorio<Pedido>
{

    private readonly ADOContext _context;


    public RepositorioPedidoADO(ADOContext context)
    {
        _context = context;

    }


    public void Create(Pedido item)
    {
        throw new NotImplementedException();
    }

    public void Update(Pedido item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }


    public Pedido? Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pedido> GetAll()
    {
        var connection = _context.GetConnection();
        var ordenadores = new List<Ordenador>();
        var componentes = new List<Componente>();
        var pedidos = new List<Pedido>();
        string sql = "SELECT COALESCE (com.Id, 0) AS Id, COALESCE (com.Categoria, '') " +
                     "AS Categoria, COALESCE (com.NumeroDeSerie, '') AS NumeroDeSerie, COALESCE (com.Precio, 0.0) " +
                     "AS PrecioCom, COALESCE (com.Descripcion, '') AS Descripcion,  COALESCE (com.Cores, 0) " +
                     "AS Cores, COALESCE (com.Grados, 0) AS Grados, COALESCE (com.Megas, 0) " +
                     "AS Megas, COALESCE (com.OrdenadorId, 0) AS OrdenadorId, ord.Id " +
                     "AS ordId, ord.Propietario, COALESCE (ord.Precio, 0)  " +
                     "AS Precio, COALESCE (ord.CalorTotal, 0) " +
                     "AS CalorTotal, COALESCE (ord.PedidoId, 0) " +
                     "AS PedidoId, Pedidos.Id " +
                     "AS IdPedido, Pedidos.Nombre, Pedidos.Precio " +
                     "AS PrecioPedido, Pedidos.Temperatura, Pedidos.Cantidad FROM Pedidos LEFT OUTER JOIN Ordenadores " +
                     "AS ord ON Pedidos.Id = ord.PedidoId LEFT OUTER JOIN Componentes " +
                     "AS com ON ord.Id = com.OrdenadorId";
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        using (SqlDataReader dataReader = command.ExecuteReader())
        {

            while (dataReader.Read())
            {
                int ordenadorId = Convert.ToInt32(dataReader["ordId"]);

                string propietario = Convert.ToString(dataReader["Propietario"])!;

                componentes.Add(new Componente()
                {
                    Id = Convert.ToInt16(dataReader["Id"]),
                    Categoria = ((CategoriasComponentes)dataReader["Categoria"]),
                    NumeroDeSerie = Convert.ToString(dataReader["NumeroDeSerie"]),
                    Descripcion = Convert.ToString(dataReader["Descripcion"]),
                    Cores = Convert.ToInt32(dataReader["Cores"]),
                    Grados = Convert.ToInt32(dataReader["Grados"]),
                    OrdenadorId = Convert.ToInt32(dataReader["OrdenadorId"]),
                    Megas = Convert.ToInt64(dataReader["Megas"]),
                    Precio = Convert.ToDecimal(dataReader["PrecioCom"])
                });


                decimal precio = Convert.ToDecimal(dataReader["Precio"]);
                int calorTotal = Convert.ToInt32(dataReader["CalorTotal"]);
                ordenadores.Add(new Ordenador()
                {
                    Id = ordenadorId,
                    Propietario = propietario,
                    Componentes = componentes,
                    Precio = precio,
                    CalorTotal = calorTotal,
                    PedidoId = 0
                });
                pedidos.Add(new Pedido()
                {
                    Ordenadores = ordenadores,
                    Nombre = Convert.ToString(dataReader["Nombre"]),
                    Precio = Convert.ToInt32(dataReader["PrecioPedido"]),
                    Cantidad = Convert.ToInt32(dataReader["Cantidad"]),
                    Id = Convert.ToInt32(dataReader["IdPedido"]),
                    Temperatura = Convert.ToInt32(dataReader["Temperatura"]),
                });
            }

        }

        connection.Close();
        return pedidos;
    }
    public string CadenaDeConexion { get; set; }
}

    

    
