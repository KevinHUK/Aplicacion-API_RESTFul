using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_ComponentesCodeFirst.App_Data;

namespace MVC_ComponentesCodeFirst.Models;

public class Componente
{
    [Key]
    public int Id { get; set; } 

    [Required(ErrorMessage = "Tienes que indicar la categoria del componente")]

    
    public CategoriasComponentes Categoria { get; set; }


    [DataType(DataType.Text)]
    [Required(ErrorMessage = "{0} no puede estar vacío")]
    [Column(TypeName = "varchar(50)")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El número de serie tiene que tener al menos 3 carácteres")]
    public string? NumeroDeSerie { get; set; }

    [Range(0,10000,ErrorMessage = "El precio no puede ser negativo; El precio no puede ser superior a 10000")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
    
    public decimal Precio { get; set; }

    [DataType(DataType.MultilineText)]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "La descripción tiene que tener al menos 3 carácteres")]
    [MaxLength(500)]
    [Column(TypeName = "varchar(500)")]
    public string? Descripcion { get; set; }

    public int? Cores { get; set; }

    public int Grados { get; set; }

    public long? Megas { get; set; }

    
    public int? OrdenadorId { get; set; }


}