using Microsoft.AspNetCore.Mvc;
using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Services;

namespace MVC_ComponentesCodeFirst.Controllers
{
	public class PedidosController : Controller
    {
        private readonly IPedidoRepositorio _repositorioPedidos;

        public PedidosController(IPedidoRepositorio repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }

        // GET: Pedidos
        public ActionResult Index()
        {
              return _repositorioPedidos.GetAllPedidos() != null ? 
                  View(_repositorioPedidos.GetAllPedidos()) :
                  Problem("Entity set 'ComponentesCodeFirstContext.Pedidos'  is null.");
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
          

            var pedido =  _repositorioPedidos.getPedidoById((int)id);
                
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _repositorioPedidos.Add(pedido);
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            

            var pedido =  _repositorioPedidos.getPedidoById((int)id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,  Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                    _repositorioPedidos.Update(pedido, id);
                     
                
                
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {

	        return View("Delete", _repositorioPedidos.getPedidoById((int)id));
	        
        }

        // POST: Pedidos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
	        try
	        {
              _repositorioPedidos.Delete(id);
              return RedirectToAction(nameof(Index));
	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		        throw;
	        }
          
        }


    }
}
