using Microsoft.AspNetCore.Mvc;
using MVC_ComponentesCodeFirst.Controllers;

using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Services;

namespace MVC_ComponentesCodeFirst.Tests
{
    [TestClass]
    public class UnitTestOrdenadores
    {
        private readonly OrdenadoresController
            controlador = new (new FakeRepositorioOrdenadores(), new FakeRepositorioComponentes());

        [TestMethod]
        public void TestOrdenadorDetailsViewFind()
        {
            var result = controlador.Details(2) as ViewResult;
            
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            var ordenador = result.ViewData.Model as Ordenador;
            Assert.IsNotNull(ordenador);
            Assert.AreEqual("Maria", ordenador.Propietario);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestOrdenadorViewNotFound()
        {
            var result = controlador.Details(4) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            var componente = result.ViewData.Model as Ordenador;
            Assert.IsNotNull(componente);
            Assert.AreEqual("Maria", componente.Propietario);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestOrdenadoPrecioTotalMaria()
        {
            var result = controlador.Details(2) as ViewResult;
            Assert.IsNotNull(result);
            var ordenador = result.ViewData.Model as Ordenador;
            Assert.IsNotNull(ordenador);
            Assert.AreEqual(25, ordenador.Precio.GetValueOrDefault());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestOrdenadoPrecioTotalAndres()
        {
            var result = controlador.Details(4) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            var ordenador = result.ViewData.Model as Ordenador;
            Assert.IsNotNull(ordenador);
            Assert.AreEqual(200, ordenador.Precio);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestOrdenadoCalorTotalMaria()
        {
            var result = controlador.Details(4) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            var ordenador = result.ViewData.Model as Ordenador;
            Assert.IsNotNull(ordenador);
            Assert.AreEqual(24, ordenador.CalorTotal);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestOrdenadoCalorTotalAndres()
        {
            var result = controlador.Details(4) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            var ordenador = result.ViewData.Model as Ordenador;
            Assert.IsNotNull(ordenador);
            Assert.AreEqual(126, ordenador.CalorTotal);
        }

        [TestMethod]
        public void TestComponentesIndexViewOk()
        {
            var result = controlador.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaOrdenadores = result.ViewData.Model as List<Ordenador>;
            Assert.IsNotNull(listaOrdenadores);
            Assert.AreEqual(2, listaOrdenadores.Count);
          
        }

    }
}