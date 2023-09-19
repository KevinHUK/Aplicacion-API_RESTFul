using Azure.Messaging.ServiceBus;
using Microsoft.Data.SqlClient;
using TiendaOrdenadoresWebApi.App_Data;
using TiendaOrdenadoresWebApi.Models;

namespace TiendaOrdenadoresWebApi.Services;

public class RepositorioComponenteADO : IRepositorio<Componente>, IConfiguracionConnectionString
{


	private readonly ADOContext _context;

	
	public RepositorioComponenteADO(ADOContext context)
	{
		_context = context;
		
		
	
	}
	public  void Create(Componente item)
	{
		var conexion = _context.GetConnection();

        using (SqlConnection connection = conexion)
		{
			connection.Open();

		
			string sqlQuery = "INSERT INTO Componentes (Categoria, NumeroDeSerie, Precio, Descripcion, Cores, Megas, Grados, OrdenadorId) " +
							  "VALUES (@Categoria, @NumeroDeSerie, @Precio, @Descripcion, @Cores, @Megas, @Grados, @OrdenadorId)";

		
			using (SqlCommand command = new SqlCommand(sqlQuery, connection))
			{
		
				command.Parameters.AddWithValue("@Categoria", item.Categoria);
				command.Parameters.AddWithValue("@NumeroDeSerie", item.NumeroDeSerie);
				command.Parameters.AddWithValue("@Precio", item.Precio);
				command.Parameters.AddWithValue("@Descripcion", item.Descripcion != null ? item.Descripcion : "");
				command.Parameters.AddWithValue("@Cores", item.Cores != null ? item.Cores : DBNull.Value) ;
				command.Parameters.AddWithValue("@Megas", item.Megas  != null ? item.Megas : DBNull.Value);
				command.Parameters.AddWithValue("@Grados", item.Grados);
				command.Parameters.AddWithValue("@OrdenadorId", item.OrdenadorId != null  ? item.OrdenadorId : DBNull.Value);

				command.ExecuteNonQuery();
				connection.Close();
			}
           

        }
        //ServiceBusClient client = new ServiceBusClient(_configuration["BusConnection"]);
        //var receiver = client.CreateReceiver(_configuration["QueueName"]);
        ////var processor = client.CreateProcessor(Configuration["BusServiceComponente"]);
        ////await processor.StartProcessingAsync();
        //var message = receiver.ReceiveMessageAsync();
        //await receiver.CompleteMessageAsync(message.Result);

    }
	 
	public void Delete(int id)
	{
		var connection = _context.GetConnection();
		string sql = "DELETE FROM Componentes WHERE Id = @Id"; 
		SqlCommand command = new SqlCommand(sql, connection);
		command.Parameters.AddWithValue("@Id", id); 
		connection.Open();

		int rowsAffected = command.ExecuteNonQuery();

		connection.Close();

		if (rowsAffected == 0)
		{
			
			throw new Exception("No se encontró ningún registro para eliminar.");
		}
	}

	public Componente? Get(int id)
	{
		var connection = _context.GetConnection();
		string sql = "SELECT * FROM Componentes WHERE Id = @Id"; 
		SqlCommand command = new SqlCommand(sql, connection);
		command.Parameters.AddWithValue("@Id", id); 
		connection.Open();

		try
		{
			using (SqlDataReader dataReader = command.ExecuteReader())
            {
                if (dataReader.Read()) 
                {
                    int componenteId = Convert.ToInt32(dataReader["Id"]);
                    string? descripcion = Convert.ToString(dataReader["Descripcion"]);
                    CategoriasComponentes categoria = (CategoriasComponentes)Enum.Parse(typeof(CategoriasComponentes), dataReader["Categoria"].ToString() ?? string.Empty);
                    string? numeroDeSerie = dataReader["NumeroDeSerie"] != DBNull.Value ? Convert.ToString(dataReader["NumeroDeSerie"]) : null;
                    decimal componentePrice = Convert.ToDecimal(dataReader["Precio"]);
                    int cores = Convert.ToInt32(dataReader["Cores"]);
                    long megas = Convert.ToInt64(dataReader["Megas"]);
                    int grados = Convert.ToInt32(dataReader["Grados"]);
                    int ordenadorId = dataReader["OrdenadorId"] != DBNull.Value ? Convert.ToInt32(dataReader["OrdenadorId"]) : 0;

                    connection.Close();
                    return new Componente()
                    {
                        Id = componenteId,
                        Categoria = categoria,
                        NumeroDeSerie = numeroDeSerie,
                        Precio = componentePrice,
                        Descripcion = descripcion,
                        Cores = cores,
                        Grados = grados,
                        Megas = megas,
                        OrdenadorId = ordenadorId
                    };

                }
                else
                {
				
                    return null;
                }
            }
		}
		finally
		{
			if (connection.State == System.Data.ConnectionState.Open)
			{
				connection.Close();
			}
		}
		
		



	}

	public IEnumerable<Componente> GetAll()
	{
		var connection = _context.GetConnection();
    
        var componentes = new List<Componente>();
		string sql = "SELECT        Id, Categoria, NumeroDeSerie, COALESCE (Precio, 0) AS Precio, Descripcion, COALESCE (Cores, 0) AS Cores, COALESCE (Grados, 0) AS Grados, COALESCE (Megas, 0) AS Megas, OrdenadorId\r\nFROM            Componentes";
		SqlCommand command = new SqlCommand(sql, connection);


        connection.Open();

        using (SqlDataReader dataReader = command.ExecuteReader())
		{
            
            while (dataReader.Read())
			{
				int componenteId = Convert.ToInt16(dataReader["Id"]);
				string? descripcion = Convert.ToString(dataReader["Descripcion"]);
				CategoriasComponentes Categoria =((CategoriasComponentes)dataReader["Categoria"]);
				string? numeroDeSerie = Convert.ToString(dataReader["NumeroDeSerie"]);
				decimal componentePrice = Convert.ToDecimal(dataReader["Precio"]);
				int cores = Convert.ToInt32(dataReader["Cores"]);
				long megas = Convert.ToInt64(dataReader["Megas"]);
				int grados = Convert.ToInt32(dataReader["Grados"]);
				var ordenadorId = dataReader["OrdenadorId"] != DBNull.Value ? Convert.ToInt32(dataReader["OrdenadorId"]) :0;
				
				componentes.Add(new Componente() { Id = componenteId,
					Categoria = Categoria 
					,NumeroDeSerie = numeroDeSerie
					, Precio = componentePrice
					, Descripcion = descripcion
					, Cores = cores, Grados = grados, Megas = megas, OrdenadorId = ordenadorId });

			}

		}

		connection.Close();
		return componentes;

	}

	public void Update(Componente item)
	{
		using (var connection = _context.GetConnection())
		{
			connection.Open();

			string updateSql = "UPDATE Componentes " +
							   "SET Categoria = @Categoria, " +
							   "Descripcion = @Descripcion, " +
							   "NumeroDeSerie = @NumeroDeSerie, " +
							   "Precio = @Precio, " +
							   "Cores = @Cores, " +
							   "Megas = @Megas, " +
							   "Grados = @Grados, " +
							   "OrdenadorId = @OrdenadorId " +
							   "WHERE Id = @Id";

			using (SqlCommand command = new SqlCommand(updateSql, connection))
			{

				command.Parameters.AddWithValue("@Categoria", item.Categoria);
				command.Parameters.AddWithValue("@Descripcion", item.Descripcion != null ? item.Descripcion : "");
				command.Parameters.AddWithValue("@NumeroDeSerie", item.NumeroDeSerie); 
				command.Parameters.AddWithValue("@Precio", item.Precio);
				command.Parameters.AddWithValue("@Cores", item.Cores != null ? item.Cores : 0);
				command.Parameters.AddWithValue("@Megas", item.Megas != null ? item.Megas : 0);
				command.Parameters.AddWithValue("@Grados", item.Grados);
				command.Parameters.AddWithValue("@OrdenadorId", item.OrdenadorId != null ? item.OrdenadorId : DBNull.Value);
				command.Parameters.AddWithValue("@Id", item.Id);
				
		

				int rowsAffected = command.ExecuteNonQuery();

				if (rowsAffected == 0)
				{
					 throw new Exception("No se encontró ningún registro para actualizar.");
				}
			}

			connection.Close();
		}
	}

	public string CadenaDeConexion { get; set; }
}