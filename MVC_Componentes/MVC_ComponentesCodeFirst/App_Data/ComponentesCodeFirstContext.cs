

using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst.Models;




namespace MVC_ComponentesCodeFirst.App_Data
{
    public class ComponentesCodeFirstContext :DbContext
    {
        public ComponentesCodeFirstContext(DbContextOptions<ComponentesCodeFirstContext> options) : base(options)
        {
        
        }



        public virtual DbSet<Componente>? Componentes { get; set; } = null!;
        public virtual DbSet<Ordenador>? Ordenadores { get; set; } = null!;
        public virtual DbSet<Pedido>? Pedidos { get; set; } = null!;
    }

  
}

