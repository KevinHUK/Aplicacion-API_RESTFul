using Microsoft.EntityFrameworkCore;
using TiendaOrdenadoresWebApi.Models;

namespace TiendaOrdenadoresWebApi.App_Data;

public class OrdenadoresContext : DbContext
{

    public OrdenadoresContext(DbContextOptions<OrdenadoresContext> options) : base(options)
    {

    }



    public virtual DbSet<Componente>? Componentes { get; set; } = null!;
    public virtual DbSet<Ordenador>? Ordenadores { get; set; } = null!;
    public virtual DbSet<Pedido>? Pedidos { get; set; } = null!;
}

