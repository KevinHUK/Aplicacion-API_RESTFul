using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MVC_ComponentesDatabaseFirst.Models;

public class DesignTimeComponenteContextFactory : IDesignTimeDbContextFactory<ComponentesDatabaseFirstContext>
{
    public ComponentesDatabaseFirstContext CreateDbContext(string[] args)
    {
        var dbContextBuilder = new DbContextOptionsBuilder<ComponentesDatabaseFirstContext>();

        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("AppConnection");

        dbContextBuilder.UseSqlServer(connectionString);
        return new ComponentesDatabaseFirstContext(dbContextBuilder.Options);
    }



}

