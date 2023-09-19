using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVC_ComponentesCodeFirst.Models.ViewModels;

public class ComponentesEnOrdenadoresViewModel
{
    public Ordenador? Ordenador { get; set; } = null!;

    public  ICollection<Componente>? ComponentesAgregados { get; set; }

}