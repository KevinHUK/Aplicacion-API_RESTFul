using System.Configuration;

namespace MVC_ComponentesCodeFirst.Services;

public class ConfiguracionMvc : IConfiguracionMVC
{
    private readonly IConfiguration _config;
   

    public ConfiguracionMvc(IConfiguration config)
    {
        
        _config = config;
        
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory() + @"\App_Data");

    }

   
    public string CadenaDeConexion{ get=>_config.GetConnectionString("AppConnection")!;
        set { }
    }
}