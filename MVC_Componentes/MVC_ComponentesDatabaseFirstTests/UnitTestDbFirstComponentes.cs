using Microsoft.AspNetCore.Mvc;
using MVC_ComponentesDatabaseFirst.Controllers;
using MVC_ComponentesDatabaseFirst.Models;
using MVC_ComponentesDatabaseFirst.Services;


namespace MVC_ComponentesDatabaseFirstTests
{

    [TestClass]
    public class UnitTestComponentes
    {
        private readonly ComponentesController
            controlador = new(new FakeRepositorioComponentes());

        [TestMethod]
        public void TestComponenteDetailsViewFind()
        {
            var result = controlador.Details(2) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            var componente = result.ViewData.Model as Componente;
            Assert.IsNotNull(componente);
            Assert.AreEqual("Procesador Intel i7", componente.Descripcion);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
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
