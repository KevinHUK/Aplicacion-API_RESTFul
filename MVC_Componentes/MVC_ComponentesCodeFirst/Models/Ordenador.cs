using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ComponentesCodeFirst.Models;

public class Ordenador
{
    
    public int Id { get; set; }


    [DataType(DataType.Text)]
    [Required(ErrorMessage = "{0} no puede estar vacío")]
    [Column(TypeName = "varchar(50)")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del propietario debe tener al menos 3 carácteres")]
    public string? Propietario { get; set; }

    [Range(0, 10000, ErrorMessage = "El precio no puede ser negativo; El precio no puede ser superior a 10000")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
    public decimal? Precio { get; set; } = 0;

    public int? CalorTotal { get; set; } = 0;

    public int? PedidoId { get; set; }
    public virtual ICollection<Componente>? Componentes { get; set; }
}