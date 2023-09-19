using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MVC_ComponentesCodeFirst.App_Data;
using MVC_ComponentesCodeFirst.Services;

namespace MVC_ComponentesCodeFirst.Models;

public class DesignTimeComponenteContextFactory : IDesignTimeDbContextFactory<ComponentesCodeFirstContext>
{
    
    public ComponentesCodeFirstContext CreateDbContext(string[] args)
    {
        IConfiguracionMVC config = new ConfiguracionMvc(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());
         
        var connectionString = config.CadenaDeConexion;
        if (args.Length == 1)
        {
            connectionString = args[0];

        }


        var dbContextBuilder = new DbContextOptionsBuilder<ComponentesCodeFirstContext>();
        dbContextBuilder.UseSqlServer(connectionString);
        return new ComponentesCodeFirstContext(dbContextBuilder.Options);
    }





}

