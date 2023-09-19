using System.ComponentModel.DataAnnotations;
using TiendaOrdenadores;
using TiendaOrdenadores.Almacen;
using TiendaOrdenadores.Componentes;
using TiendaOrdenadores.Factoria;
using TiendaOrdenadores.Factoria.Enumeradores;
using TiendaOrdenadores.Factoria.Interfaces;
using TiendaOrdenadores.Factura;
using TiendaOrdenadores.Pedidos;
using TiendaOrdenadores.Validadores;

namespace TestTiendaOrdenadores.Apartado_D
{
    [TestClass]
    public class TestOrdendoresD
    {
        private readonly Ordenador _ordenadorMaria = new();
        private readonly Ordenador _ordenadorAndres = new();
        private readonly Ordenador _ordenadorTirburcioII = new();
        private readonly Ordenador _ordenadorAndresCF = new();
        private OrdenadorConAlmacenamientoPrimarioDecorator? _ordenadorTiburcioIICompleto;
        private OrdenadorConAlmacenamientoPrimarioDecorator? _ordenadorAndresCFCompleto;
        private readonly Pedido _pedidoA = new();
        private readonly Pedido _pedidoB = new();
        private readonly List<IComponente> _listaMemoriasExtraT = new();
        private readonly List<IComponente> _listaMemoriasExtraA = new();
        private readonly IFactura _facturaA = new Factura();
        private readonly IFactura _facturaB = new Factura();
        private readonly IFactura _facturaC = new Factura();
        private readonly IAlmacen _almacen = new Almacen();
        private readonly ValidationAttribute _validador = new ValidadorAlmacenAttribute();
        private  ComponenteDecorator? NoStockItem; 
        
        [TestInitialize]
        public void TestInitialize()
        {
            IComponenteFactoryMethod factoriaComponentesStock = new FactoriaComponentesStock();

            var discoPrimarioT =(ComponenteDecorator?) factoriaComponentesStock.DameComponente(TipoComponentes._789XX);
            var procesadorT = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._789XCS);
            var memoriaRam = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._879FH);
            var discoExt = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._1789XCS);
            var discoMecanico = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._788fg);

            if (discoPrimarioT != null && procesadorT != null && memoriaRam != null && discoExt != null && discoMecanico != null)
            {
                _ordenadorTirburcioII.Add(procesadorT);
                _ordenadorTirburcioII.Add(discoExt);
                _ordenadorTirburcioII.Add(memoriaRam);
                _listaMemoriasExtraT.Add(discoPrimarioT);
                _listaMemoriasExtraT.Add(discoMecanico);
                _almacen.Add(procesadorT);
                _almacen.Add(memoriaRam);
                _almacen.Add(discoPrimarioT);
                _almacen.Add(discoMecanico);
                _almacen.Add(procesadorT);
            }

            var discoPrimarioA = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._788fg);
            var procesadorA = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._789XCS);
            var memoriaRamA = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._879FHT);
            var discoDuroA = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._789XX3);

            if (discoPrimarioA != null && procesadorA != null && memoriaRamA != null && discoDuroA != null)
            {
                _ordenadorAndresCF.Add(procesadorA);
                _ordenadorAndresCF.Add(memoriaRamA);
                _ordenadorAndresCF.Add(discoDuroA);
                _listaMemoriasExtraA.Add(discoPrimarioA);
                _almacen.Add(procesadorA);
                _almacen.Add(memoriaRamA);
                _almacen.Add(discoDuroA);
                _almacen.Add(discoPrimarioA);
            }

            var discoM = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._789XX);
            var procesadorM = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._789XCS);
            var memoriaM = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._879FH);

            if (discoM != null && procesadorM != null && memoriaM != null)
            {
                _ordenadorMaria.Add(discoM);
                _ordenadorMaria.Add(procesadorM);
                _ordenadorMaria.Add(memoriaM);
                _almacen.Add(discoM);
                _almacen.Add(procesadorM);
                _almacen.Add(memoriaM);
            }

            var disco = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._879FHT);
            var procesador = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._789XX3);
            var memoria = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._797X3);

            if (disco != null && procesador != null && memoria != null)
            {
                _ordenadorAndres.Add(disco);
                _ordenadorAndres.Add(procesador);
                _ordenadorAndres.Add(memoria);
                _almacen.Add(disco);
                _almacen.Add(procesador);
                _almacen.Add(memoria);
            }

            _pedidoA.AddPedido(_ordenadorMaria);
            _pedidoA.AddPedido(_ordenadorAndres);

            _ordenadorTiburcioIICompleto = new(_ordenadorTirburcioII, _listaMemoriasExtraT);
            _ordenadorAndresCFCompleto = new(_ordenadorAndresCF, _listaMemoriasExtraA);

            _pedidoB.AddPedido(_ordenadorTiburcioIICompleto);
            _pedidoB.AddPedido(_ordenadorAndresCFCompleto);


            NoStockItem = (ComponenteDecorator?)factoriaComponentesStock.DameComponente(TipoComponentes._1789XCT);


            Assert.IsTrue(_validador.IsValid(_almacen.GetComponentes().Find(c=>c.NumeroDeSerie.Length>0)));

            

            _facturaA.Add(_pedidoA);
            _facturaB.Add(_pedidoB);
            _facturaC.Add(_pedidoA);
            _facturaC.Add(_pedidoB);
        }



        [TestMethod]
        public void TestFacturaA_Stock()
        {
            Assert.IsNotNull(_facturaA);

            foreach (var componente in from pedido in _facturaA.DameFactura() from ordenador in pedido.GetPedidos().Keys from componente in ordenador.DameOrdenador() select componente)
            {
                Assert.IsTrue(_validador.IsValid(_almacen.GetComponentes().Find(c => c.Equals(componente))));
            }
        }

        [TestMethod]
        public void TestFacturaA_Facturacion()
        {
            Assert.IsNotNull(_pedidoA);
            Assert.AreEqual(840, _facturaA.GetFacturacion());


        }

        [TestMethod]
        public void TestFacturaB_Stock()
        {
            Assert.IsNotNull(_facturaB);

            foreach (var componente in from pedido in _facturaB.DameFactura() from ordenador in pedido.GetPedidos().Keys from componente in ordenador.DameOrdenador() select componente)
            {
                Assert.IsTrue(_validador.IsValid(_almacen.GetComponentes().Find(c => c.Equals(componente))));
            }
        }

        [TestMethod]
        public void TestFacturaB_Facturacion()
        {
            Assert.IsNotNull(_pedidoB);
            Assert.AreEqual(904, _facturaB.GetFacturacion());


        }



        [TestMethod]
        public void TestFacturaC_Stock()
        {
            Assert.IsNotNull(_facturaC);

            foreach (var componente in from pedido in _facturaC.DameFactura() from ordenador in pedido.GetPedidos().Keys from componente in ordenador.DameOrdenador() select componente)
            {
                Assert.IsTrue(_validador.IsValid(_almacen.GetComponentes().Find(c => c.Equals(componente))));
            }
        }

        [TestMethod]
        public void TestFacturaC_Facturacion()
        {
            Assert.IsNotNull(_pedidoA);
            Assert.IsNotNull(_pedidoB);
            Assert.AreEqual(1744, _facturaC.GetFacturacion());
        }


        [TestMethod]

        public void TestFactura_ControlStock()
        {
            if (NoStockItem != null) _ordenadorAndres.Add(NoStockItem);
            _pedidoA.AddPedido(_ordenadorAndres);
            foreach (var componente in from pedido in _facturaC.DameFactura() from ordenador in pedido.GetPedidos().Keys from componente in ordenador.DameOrdenador() select componente)
            {
                Assert.IsTrue(_validador.IsValid(_almacen.GetComponentes().Find(c => c.Equals(componente))));
            }
        }

    }
}