using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.ObjetosDeValor
{
    [TestClass]
    public class CedulaTest
    {
        [TestMethod]
        public void Constructor_Cedula_LanzaException()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Cedula(null!));
        }
        [TestMethod]
        public void Constructor_CedulaSinGuion_LanzaException()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Cedula("1001010106"));
        }
        [TestMethod]
        public void Constructor_CedulaMayorADiezDigitos_LanzaException()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Cedula("1001010106-2"));
        }
        [TestMethod]
        public void Constructor_CedulaMenorADiezDigitos_LanzaException()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Cedula("10010101-2"));
        }
        [TestMethod]
        public void Constructor_Cedula_NoLanzaException()
        {
            try
            {
                new Cedula("100101010-2");
            }
            catch
            {
                Assert.Fail("No debe lanzar excepciones.");
            }
        }
    }
}
