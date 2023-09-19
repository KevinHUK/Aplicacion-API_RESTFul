using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresWebApi.Controllers;
using TiendaOrdenadoresWebApi.Models;
using TiendaOrdenadoresWebApi.Services;

namespace WEBAPI_TiendaOrdenadoresTest
{
    [TestClass]
    public class TestComponentesController
    {
        readonly ComponentesController controlador;


        public TestComponentesController()
        {
            controlador = new(new FakeRepositorioComponentes());
        }

        [TestMethod]
        public void TestObtenerTodos()
        {
            var resultado = controlador.GetComponentes() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);
        }

        [TestMethod]
        public void TestObtenerComponenteExiste()
        {
            var resultado = controlador.GetComponente(1) as OkObjectResult;
            Assert.IsNotNull(resultado);
            var componente = resultado.Value as Componente;
            Assert.IsNotNull(componente);
            Assert.AreEqual(0, componente.Categoria);
            Assert.AreEqual("patata", componente.Descripcion);
            Assert.AreEqual(10, componente.Grados);
            Assert.AreEqual("Cores", componente.Megas);
            Assert.AreEqual(50, componente.Precio);
            Assert.AreEqual("AAAA", componente.NumeroDeSerie);
        }

        [TestMethod]
        public void TestObtenerComponenteNoExiste()
        {
            var resultado = controlador.GetComponente(1) as NotFoundResult;
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void TestComponentesCrearBien()
        {
            var resultado = controlador.GetComponentes() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            Componente componente = new()
            {
                Descripcion = "Prueba",
                NumeroDeSerie = "BBBB"
            };

            controlador.PostComponente(componente);
            resultado = controlador.GetComponentes() as OkObjectResult;
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(4, listaModulos.Count);
        }

        [TestMethod]
        public void TestComponentesBorrarExiste()
        {
            var resultado = controlador.GetComponentes() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            controlador.DeleteComponente(3);
            resultado = controlador.GetComponentes() as OkObjectResult;
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(2, listaModulos.Count);
        }

        [TestMethod]
        public void TestComponentesBorrarNoExiste()
        {
            var resultado = controlador.GetComponentes() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            controlador.DeleteComponente(999);
            resultado = controlador.GetComponentes() as OkObjectResult;
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);
        }
      
    }
}