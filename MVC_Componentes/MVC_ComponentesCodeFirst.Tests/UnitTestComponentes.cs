using Microsoft.AspNetCore.Mvc;
using MVC_ComponentesCodeFirst.Controllers;
using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Services;

namespace MVC_ComponentesCodeFirst.Tests
{
    [TestClass]
    public class UnitTestComponentes
    {
        private readonly ComponentesController
            controlador = new (new FakeRepositorioComponentes());

        [TestMethod]
        public void TestComponenteDetailsViewFind()
        {
	        var result = controlador.Details(1) as ViewResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Details", result.ViewName);
			Assert.IsNotNull(result.ViewData.Model);

			var componente = result.ViewData.Model as Componente;

			Assert.IsNotNull(componente);
			
		}

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestComponenteViewNotFound()
        {
            var result = controlador.Details(4) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            var componente = result.ViewData.Model as Componente;
            Assert.IsNotNull(componente);
            Assert.AreEqual("Procesador Intel i7", componente.Descripcion);
        }

        [TestMethod]
        public void TestComponentesIndexViewOk()
        {
            var result = controlador.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaComponentes = result.ViewData.Model as List<Componente>;
            Assert.IsNotNull(listaComponentes);
            Assert.AreEqual(3, listaComponentes.Count);
          
        }

    }
}