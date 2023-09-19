namespace TiendaOrdenadoresWebApi.Services;

public class ConfigurationConnectionString : IConfiguracionConnectionString
{
    private readonly IConfiguration _config;
   

    public ConfigurationConnectionString(IConfiguration config)
    {
	    _config = config;
        AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory() + @"\App_Data");
    }

   
    public string CadenaDeConexion{ get=>_config.GetConnectionString("AppConnection")!;
        set { }
    }
}