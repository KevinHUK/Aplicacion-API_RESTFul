using Humanizer;
using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresWebApi.Models;
using TiendaOrdenadoresWebApi.Services;

namespace TiendaOrdenadoresWebApi.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class ComponentesController : ControllerBase
    {
        private readonly IRepositorio<Componente> _repositorioComponente;

		public ComponentesController(IRepositorio<Componente> repositorioComponente)
        {
			_repositorioComponente=repositorioComponente;
      


        }

        // GET: api/Componentes
        [HttpGet]
        public  IActionResult GetComponentes()
        {
			var componentes = _repositorioComponente.GetAll();

			if (!componentes.Any())
			{
				return NotFound("No se encontraron componentes.");
			}

			return Ok(componentes);
		}

        // GET: api/Componentes/5
        [HttpGet("{id}")]
        public IActionResult GetComponente(int id)
        {
			var componente = _repositorioComponente.Get(id);

			if (componente == null)
			{
				return NotFound();
			}

			return Ok(componente);
		}

        // PUT: api/Componentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutComponente(int id, Componente componente)
        {
            if (id != componente.Id )
            {
                return NotFound();
            }

        
            _repositorioComponente.Update(componente) ;

            return NoContent();
        }

        //POST: api/Componentes
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostComponente(Componente componente)
        {
            try
            {
                _repositorioComponente.Create(componente);
              

            }
            catch
            {
                return Problem("Entity set 'OrdenadoresContext.Componentes'  is null.");
            }

            return CreatedAtAction("GetComponente", new { id = componente.Id });

        }

 
        // DELETE: api/Componentes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteComponente(int id)
        {

            try
            {
                var componente = _repositorioComponente.Get(id);
                _repositorioComponente.Delete(componente.Id);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

  
    }
}
