using TiendaOrdenadores.Comportamientos;

namespace TestTiendaOrdenadores.ComportamientosTest;


[TestClass]
public class TestComportamientos
{
    [TestMethod]
    public void SinSerializarTest()
    {
        Assert.AreEqual("", new SinSerializar().NumeroDeSerie);
    }
    [TestMethod]
    public void SerializableTest()
    {
        Assert.AreEqual("test", new Serializable("test").NumeroDeSerie);
    }

    [TestMethod]
    public void SinAlmacenamientoTest()
    {
        Assert.AreEqual(0, new SinAlmacenamiento().Almacenamiento);
    }

    [TestMethod]
    public void ConAlmacenamientoTest()
    {
        Assert.AreEqual(1, new ConAlmacenamiento(1).Almacenamiento);
    }

    [TestMethod]
    public void SinCalorTest()
    {
        Assert.AreEqual(0, new SinCalor().Calor);
    }

    [TestMethod]
    public void ConCalorTest()
    {
        Assert.AreEqual(1, new ConCalor(1).Calor);
    }

    [TestMethod]
    public void SinCoresTest()
    {
        Assert.AreEqual(0, new SinCores().Cores);
    }

    [TestMethod]
    public void ConCoresTest()
    {
        Assert.AreEqual(1, new ConCores(1).Cores);
    }


    [TestMethod]
    public void SinCosteTest()
    {
        Assert.AreEqual(0, new SinCoste().Precio);
    }

    [TestMethod]
    public void ConCosteTest()
    {
        Assert.AreEqual(1, new ConCoste(1).Precio);
    }
}