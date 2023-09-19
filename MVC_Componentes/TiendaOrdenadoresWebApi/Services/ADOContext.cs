
using Microsoft.Data.SqlClient;

namespace TiendaOrdenadoresWebApi.Services
{
	public class ADOContext
	{
		private readonly SqlConnection _connection;

		public ADOContext()
		{
			IConfiguracionConnectionString config = new ConfigurationConnectionString(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());
			var connectionString1 = config.CadenaDeConexion;
			_connection = new SqlConnection(connectionString1);

			_connection.Close();
		}

		public SqlConnection GetConnection()
		{
			return _connection;
		}
	}
}