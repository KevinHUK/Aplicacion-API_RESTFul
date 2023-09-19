using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ComponentesCodeFirst.Models;

public class Pedido
{
    public int Id { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "{0} no puede estar vacío")]
    [Column(TypeName = "varchar(50)")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no puede estar vacío")]
	public string? Nombre { get; set; }

    [DisplayName("Precio del pedido")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
	public decimal? Precio { get; set; }

    [DisplayName("Temperatura total del pedido")]
    public int? Temperatura { get; set; }
    public virtual ICollection<Ordenador>? Ordenadores { get; set; }

    [DisplayName("Nº de ordenadores que conforman el pedido")]
    public int? Cantidad { get; set; }
}