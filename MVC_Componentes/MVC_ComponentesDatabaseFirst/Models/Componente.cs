using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ComponentesDatabaseFirst.Models;

public partial class Componente
{
    [Key]
    public int ComponenteId { get; set; }

    public int Categoria { get; set; }

    [StringLength(50)]
    public string NumeroDeSerie { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Precio { get; set; }

    [StringLength(50)]
    public string? Descripcion { get; set; }

    public int Cores { get; set; }

    public int Grados { get; set; }

    public long Megas { get; set; }
}
