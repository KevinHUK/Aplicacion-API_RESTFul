using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresWebApi.Models;
using TiendaOrdenadoresWebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaOrdenadoresWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdenadoresController : ControllerBase
	{
		private readonly IRepositorio<Ordenador> _repositorioOrdenador;
		public OrdenadoresController(IRepositorio<Ordenador> repositorioOrdenador)
		{
			_repositorioOrdenador = repositorioOrdenador;

		}
		// GET: api/<OrdenadoresController>
		[HttpGet]
		public IActionResult GetOrdenadores()
		{
			var ordenadores = _repositorioOrdenador.GetAll();

			if (!ordenadores.Any())
			{
				return NotFound("No se encontraron ordenadores.");
			}

			return Ok(ordenadores);
		}

		// GET api/<OrdenadoresController>/5
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var ordenador = _repositorioOrdenador.Get(id);

			if (ordenador == null)
			{
				return NotFound();
			}

			return Ok(ordenador);
		}

		// POST api/<OrdenadoresController>
		[HttpPost]
		public IActionResult Post(Ordenador ordenador)
		{
            try
            {
                _repositorioOrdenador.Create(ordenador);
            }
            catch
            {
                return Problem("Entity set 'OrdenadoresContext.Componentes'  is null.");
            }

			return CreatedAtAction("GetById", new { id = ordenador.Id });
		}

		// PUT api/<OrdenadoresController>/5
		[HttpPut("{id}")]
		public IActionResult PutOrdenador(int id, [FromBody] Ordenador ordenador)
		{
			
				if (id != ordenador.Id)
				{
					return NotFound();
				}


                _repositorioOrdenador.Update(ordenador);

				return NoContent();
			
		}

		// DELETE api/<OrdenadoresController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
            try
            {
                var ordenador = _repositorioOrdenador.Get(id);
                _repositorioOrdenador.Delete(ordenador.Id);
            }
            catch
            {
                return NotFound();
            }

			return NoContent();
		}
	}
}
