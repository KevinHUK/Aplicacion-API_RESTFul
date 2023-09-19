using TiendaOrdenadores;
using TiendaOrdenadores.Componentes;
using TiendaOrdenadores.Factoria;
using TiendaOrdenadores.Factoria.Enumeradores;
using TiendaOrdenadores.Factoria.Interfaces;

namespace TestTiendaOrdenadores
{
    [TestClass]
    public class TestOrdendoresAnexoI
    {

        private readonly Ordenador _ordenadorMaria = new();
        private readonly Ordenador _ordenadorAndres = new();
        private readonly Ordenador _ordenadorTirburcioII = new();
        private readonly Ordenador _ordenadorAndresCF = new();
        private OrdenadorConAlmacenamientoPrimarioDecorator? _ordenadorTiburcioIICompleto;
        private OrdenadorConAlmacenamientoPrimarioDecorator? _ordenadorAndresCFCompleto;
        private readonly List<IComponente> _listaExtra = new();
        private readonly List<IComponente> _listaExtra2 = new();

        [TestInitialize]
        public void TestInitialize()
        {

            IComponenteFactoryMethod factoria = new FactoriaComponentes();


            var discoPrimarioT = factoria.DameComponente(TipoComponentes._789XX);
            var procesadorT = factoria.DameComponente(TipoComponentes._789XCS);
            var memoriaRam = factoria.DameComponente(TipoComponentes._879FH);
            var discoExt = factoria.DameComponente(TipoComponentes._1789XCS);
            var discoMecanico = factoria.DameComponente(TipoComponentes._788fg);

            if (discoPrimarioT != null && procesadorT != null && memoriaRam != null && discoExt != null && discoMecanico != null)
            {
                _ordenadorTirburcioII.Add(procesadorT);
                _ordenadorTirburcioII.Add(discoExt);
                _ordenadorTirburcioII.Add(memoriaRam);
                _listaExtra.Add(discoPrimarioT);
                _listaExtra.Add(discoMecanico);
            }


            _ordenadorTiburcioIICompleto = new(_ordenadorTirburcioII,
                _listaExtra);


            var discoPrimarioA = factoria.DameComponente(TipoComponentes._788fg);
            var procesadorA = factoria.DameComponente(TipoComponentes._789XCS);
            var memoriaRamA = factoria.DameComponente(TipoComponentes._879FHT);
            var discoDuroA = factoria.DameComponente(TipoComponentes._789XX3);

            if (discoPrimarioA != null && procesadorA != null && memoriaRamA != null && discoDuroA != null)
            {
                _ordenadorAndresCF.Add(procesadorA);
                _ordenadorAndresCF.Add(memoriaRamA);
                _ordenadorAndresCF.Add(discoDuroA);
                _listaExtra2.Add(discoPrimarioA);
            }


            _ordenadorAndresCFCompleto = new(_ordenadorAndresCF, _listaExtra2);


            var discoM = factoria.DameComponente(TipoComponentes._789XX);
            var procesadorM = factoria.DameComponente(TipoComponentes._789XCS);
            var memoriaM = factoria.DameComponente(TipoComponentes._879FH);


            if (discoM != null && procesadorM != null && memoriaM != null)
            {
                _ordenadorMaria.Add(discoM);
                _ordenadorMaria.Add(procesadorM);
                _ordenadorMaria.Add(memoriaM);
            }






            var disco = factoria.DameComponente(TipoComponentes._879FHT);
            var procesador = factoria.DameComponente(TipoComponentes._789XX3);
            var memoria = factoria.DameComponente(TipoComponentes._797X3);


            if (disco != null && procesador != null && memoria != null)
            {
                _ordenadorAndres.Add(disco);
                _ordenadorAndres.Add(procesador);
                _ordenadorAndres.Add(memoria);
            }





        }

        [TestMethod]
        public void TestOrdenadorMariaPrecio()
        {
            Assert.AreEqual(284, _ordenadorMaria.PrecioPorOrdenador);

        }
        [TestMethod]
        public void TestOrdenadorMariaIsNotNull()
        {
            Assert.IsNotNull(_ordenadorMaria);

        }
        [TestMethod]
        public void TestOrdenadorMariaCalor()
        {
            Assert.AreEqual(30, _ordenadorMaria.CalorTotal);

        }
        [TestMethod]
        public void TestOrdenadorAndresPrecio()
        {
            Assert.AreEqual(556, _ordenadorAndres.PrecioPorOrdenador);

        }
        [TestMethod]
        public void TestOrdenadorAndresCalor()
        {
            Assert.AreEqual(123, _ordenadorAndres.CalorTotal);

        }
        [TestMethod]
        public void TestOrdenadorAndresIsNotNull()
        {
            Assert.IsNotNull(_ordenadorAndres);

        }
        [TestMethod]
        public void TestOrdenadorTiburcioPrecio()
        {
            Assert.IsNotNull(_ordenadorTiburcioIICompleto);
            Assert.AreEqual(455, _ordenadorTiburcioIICompleto.PrecioPorOrdenador);
        }
        [TestMethod]
        public void TestOrdenadorTiburcioCalor()
        {
            Assert.IsNotNull(_ordenadorTiburcioIICompleto);
            Assert.AreEqual(75, _ordenadorTiburcioIICompleto.CalorTotal);

        }
        [TestMethod]
        public void TestOrdenadorTiburcioIsNotNull()
        {
            Assert.IsNotNull(_ordenadorTiburcioIICompleto);

        }
        [TestMethod]
        public void TestOrdenadorAndresCFPrecio()

        {
            Assert.IsNotNull(_ordenadorAndresCFCompleto);
            Assert.AreEqual(449, _ordenadorAndresCFCompleto.PrecioPorOrdenador);

        }
        [TestMethod]
        public void TestOrdenadorAndresCFCalor()
        {
            Assert.IsNotNull(_ordenadorAndresCFCompleto);
            Assert.AreEqual(108, _ordenadorAndresCFCompleto.CalorTotal);

        }
        [TestMethod]
        public void TestOrdenadorAndresCFIsNotNull()
        {
            Assert.IsNotNull(_ordenadorAndresCFCompleto);

        }
    }
}