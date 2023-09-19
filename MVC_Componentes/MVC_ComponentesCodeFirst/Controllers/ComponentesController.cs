using Microsoft.AspNetCore.Mvc;
using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Services;

namespace MVC_ComponentesCodeFirst.Controllers
{
    public class ComponentesController : Controller
    {

        
        private readonly IComponenteRepositorio _repositorioComponente;

        public ComponentesController(IComponenteRepositorio repositorioComponente)
        {
            _repositorioComponente = repositorioComponente;

        }
        // GET: Componentes
        public ActionResult Index()
        {
            return View("Index", _repositorioComponente.All());
        }

        // GET: Componentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Componente? componente = _repositorioComponente.GetById((int)id);

            if (componente == null)
            {
                return NotFound();
            }

            return View("Details", componente);
        }

        // GET: Componentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Componentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Componente componente)
        {
            if (ModelState.IsValid)
            {
                _repositorioComponente.Add(componente);

                return RedirectToAction(nameof(Index));
            }
            return View(componente);
        }

        // GET: Componentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = _repositorioComponente.GetById((int)id);
            if (componente == null)
            {
                return NotFound();
            }
            return View(componente);
        }

        // POST: Componentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Componente componente, int id)
        {
            if (ModelState.IsValid)
            {
                _repositorioComponente.Update(componente, id);
                

                return RedirectToAction(nameof(Index));
            }
            return View(componente);
        }

        // GET: Componentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componente = _repositorioComponente.GetById((int)id);
            if (componente == null)
            {
                return NotFound();
            }
            _repositorioComponente.Delete(componente.Id);
            return View(componente);
        }

        // POST: Componentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Componente? componente = _repositorioComponente.GetById(id);
            _repositorioComponente.Delete(componente!.Id);

            return RedirectToAction(nameof(Index));
        }


    }
}
