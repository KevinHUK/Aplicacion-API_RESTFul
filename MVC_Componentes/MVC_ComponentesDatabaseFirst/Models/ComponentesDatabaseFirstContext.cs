using Microsoft.EntityFrameworkCore;

namespace MVC_ComponentesDatabaseFirst.Models;

public  class ComponentesDatabaseFirstContext : DbContext
{


    public ComponentesDatabaseFirstContext(DbContextOptions<ComponentesDatabaseFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Componente>? Componentes { get; set; }




}
