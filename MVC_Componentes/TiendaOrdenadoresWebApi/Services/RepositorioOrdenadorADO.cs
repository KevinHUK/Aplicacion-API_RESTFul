using Microsoft.Data.SqlClient;
using TiendaOrdenadoresWebApi.App_Data;
using TiendaOrdenadoresWebApi.Models;

namespace TiendaOrdenadoresWebApi.Services;

public class RepositorioOrdenadorADO : IRepositorio<Ordenador>, IConfiguracionConnectionString
{


	private readonly ADOContext _context;

	
	public RepositorioOrdenadorADO(ADOContext context)
	{
		_context = context;
		
	}
	

	public void Update(Ordenador item)
	{
		throw new NotImplementedException();
	}

	public void Delete(int id)
	{
		throw new NotImplementedException();
	}


	public IEnumerable<Ordenador> GetAll()
	{
		var connection = _context.GetConnection();
		var ordenadores = new List<Ordenador>();
		var componentes = new List<Componente>();
		string sql = "SELECT        coalesce(com.Id, 0) as Id, coalesce(com.Categoria, '') as Categoria, coalesce(com.NumeroDeSerie, '') as NumeroDeSerie, coalesce(com.Precio, 0.0) as PrecioCom, coalesce(com.Descripcion, '') as Descripcion, coalesce(com.Cores, 0) as Cores, coalesce(com.Grados, 0) as Grados, coalesce(com.Megas, 0) as Megas, coalesce(com.OrdenadorId, 0) as OrdenadorId, ord.Id AS ordId, ord.Propietario, coalesce(ord.Precio, 0) AS Precio, coalesce(ord.CalorTotal, 0) CalorTotal, coalesce(ord.PedidoId, 0) as PedidoId\r\nFROM            Componentes AS com RIGHT OUTER JOIN\r\n                         Ordenadores AS ord ON com.OrdenadorId = ord.Id ";
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
					OrdenadorId =  Convert.ToInt32(dataReader["OrdenadorId"]),
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

			}

		}

		connection.Close();
		return ordenadores;
	}

	public Ordenador Get(int id)
	{
        var connection = _context.GetConnection();
		var ordenador = new Ordenador();
        var componentes = new List<Componente>();
        string sql = "select com.*, ord.* from Componentes as com inner join Ordenadores as ord on com.OrdenadorId = ord.Id where ord.Id = @Id and com.OrdenadorId = @Id";

        SqlCommand command = new SqlCommand(sql, connection);
		command.Parameters.AddWithValue("@Id", id); 
        connection.Open();
        using (SqlDataReader dataReader = command.ExecuteReader())
        {

            while (dataReader.Read())
            {
                int ordenadorId = Convert.ToInt16(dataReader["Id"]);
                string propietario = Convert.ToString(dataReader["Propietario"])!;

                componentes.Add(new Componente()
                {
                    Id = Convert.ToInt16(dataReader["Id"]),
                    Categoria = ((CategoriasComponentes)dataReader["Categoria"]),
                    NumeroDeSerie = Convert.ToString(dataReader["NumeroDeSerie"]),
                    Descripcion = Convert.ToString(dataReader["Descripcion"]) != null ? Convert.ToString(dataReader["Descripcion"]) : "",
                    Cores = Convert.ToInt32(dataReader["Cores"]),
                    Grados = Convert.ToInt32(dataReader["Grados"]),
                    OrdenadorId = dataReader["OrdenadorId"] != DBNull.Value ? Convert.ToInt32(dataReader["OrdenadorId"]) : 0,
                    Megas = Convert.ToInt64(dataReader["Megas"]),
                    Precio = Convert.ToDecimal(dataReader["Precio"])
                });


                decimal precio = Convert.ToDecimal(dataReader["Precio"]);
                int calorTotal = Convert.ToInt32(dataReader["CalorTotal"]);
                ordenador = new Ordenador()
                {
                    Id = ordenadorId,
                    Propietario = propietario,
                    Componentes = componentes,
                    Precio = precio,
                    CalorTotal = calorTotal,
                    PedidoId = 0
                };

            }

        }

        connection.Close();
        return ordenador;
    }

	public void Create(Ordenador ordenador)
	{
		var connection = _context.GetConnection();
		string sql = "INSERT INTO Ordenadores (Propietario, PedidoId) " +
		             "VALUES (@Propietario, @PedidoId)";
		SqlCommand command = new SqlCommand(sql, connection);

		command.Parameters.AddWithValue("@Propietario", ordenador.Propietario);

		command.Parameters.AddWithValue("@PedidoId", ordenador.PedidoId != null ? ordenador.PedidoId : DBNull.Value);

		connection.Open();

		int rowsAffected = command.ExecuteNonQuery();

		connection.Close();

		if (rowsAffected == 0)
		{
			throw new Exception("No se pudo insertar el registro.");
		}
	}



	public string CadenaDeConexion { get; set; }
}