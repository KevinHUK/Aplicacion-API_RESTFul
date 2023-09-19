using Microsoft.AspNetCore.Mvc;
using MVC_ComponentesCodeFirst.Services;

namespace MVC_ComponentesCodeFirst.Models;

public class ComponentesListadosViewComponent : ViewComponent
{
	private readonly IRepositorioOrdenador _repositorioOrdenador;
	public ComponentesListadosViewComponent(IRepositorioOrdenador repositorioOrdenador)
	{
		_repositorioOrdenador = repositorioOrdenador;
	}
	public Task<IViewComponentResult> InvokeAsync(int Id)
	{
		var items = _repositorioOrdenador.GetOrdenador(Id)?.Componentes;


		return Task.FromResult<IViewComponentResult>(View("ComponentesListados", items));
	}

}