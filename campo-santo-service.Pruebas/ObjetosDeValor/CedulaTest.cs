using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.ObjetosDeValor
{
    [TestClass]
    public class CedulaTest
    {
        [TestMethod]
        public void Constructor_Cedula_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Cedula(null!));
        }
        [TestMethod]
        public void Constructor_CedulaSinGuion_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Cedula("1001010106"));
        }
        [TestMethod]
        public void Constructor_CedulaMayorADiezDigitos_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Cedula("1001010106-2"));
        }
        [TestMethod]
        public void Constructor_CedulaEsVacio_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Cedula(""));
        }
        [TestMethod]
        public void Constructor_CedulaMenorADiezDigitos_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Cedula("10010101-2"));
        }
        [TestMethod]
        public void Constructor_Cedula_NoLanzaExcepcion()
        {
            var cedula = new Cedula("100101010-2").Valor;
            Assert.IsNotNull(cedula);
        }
    }
}
