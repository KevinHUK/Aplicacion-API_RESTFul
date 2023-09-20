using Microsoft.AspNetCore.Mvc;
using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Models.ViewModels;
using MVC_ComponentesCodeFirst.Services;

namespace MVC_ComponentesCodeFirst.Controllers
{
    public class OrdenadoresController : Controller
    {
        private readonly IRepositorioOrdenador _ordenadorRepositorio;
        private readonly IRepositorio<Componente> _componenteRepositorio;
        public OrdenadoresController(IRepositorioOrdenador ordenadorRepositorio, IRepositorio<Componente> componenteRepositorio)
        {
            _ordenadorRepositorio = ordenadorRepositorio;
            _componenteRepositorio = componenteRepositorio;


        }


        // GET: Ordenadors
        public ActionResult Index()
        {

            return View("Index", _ordenadorRepositorio.GetOrdenadorList());
        }

        // GET: Ordenadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            Ordenador? ordenador = _ordenadorRepositorio.GetOrdenador((int)id);

            ComponentesEnOrdenadoresViewModel viewModel = new ComponentesEnOrdenadoresViewModel
            {
                Ordenador = ordenador,
                ComponentesAgregados = ordenador!.Componentes!.ToList()
            };

            return View("Details", viewModel);
        }

        // GET: Ordenadors/Create
        public IActionResult Create()
        {


            

            return View();
        }

        // POST: Ordenadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Ordenador ordenador)
        {
            if (ModelState.IsValid)
            {
                _ordenadorRepositorio.AddOrdenador(ordenador);
                return RedirectToAction(nameof(Index));
            }
            return View(ordenador);
        }

        // GET: Ordenadors/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(_ordenadorRepositorio.GetOrdenador((int)id));
        }
        

        // POST: Ordenadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ordenador ordenador)
        {

            if (ModelState.IsValid)
            {
               
                    _ordenadorRepositorio.Update(ordenador, id);
               
                return RedirectToAction(nameof(Index));
            }
            return View(ordenador);
        }


        //GET: Ordenadors/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null || _ordenadorRepositorio.GetOrdenador((int)id) == null)
            {
                return NotFound();
            }

            var ordenador = _ordenadorRepositorio.GetOrdenador((int)id);
            if (ordenador == null)
            {
                return NotFound();
            }

            return View(ordenador);
        }
        //#1#

         //POST: Ordenadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_ordenadorRepositorio.GetOrdenador(id) == null)
            {
                return Problem("Entity set 'ComponentesCodeFirstContext.Ordenador'  is null.");
            }

            var ordenador = _ordenadorRepositorio.GetOrdenador((int)id);

			if (ordenador != null)
            {
                _ordenadorRepositorio.DeleteOrdenador(id);
            }

            
            return RedirectToAction(nameof(Index));
        }


    }
}
