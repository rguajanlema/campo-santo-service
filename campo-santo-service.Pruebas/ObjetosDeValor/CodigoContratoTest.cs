using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.ObjetosDeValor
{
    [TestClass]
    public class CodigoContratoTest
    {
        [TestMethod]
        public void Constructor_CodigoContratoNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new CodigoContrato(null!));
        }
        [TestMethod]
        public void Constructor_CodigoContratoPatronIncorrecto_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new CodigoContrato("0-000"));
        }
        [TestMethod]
        public void Constructor_NoLanzaExcepcion()
        {
            var codigo = new CodigoContrato("C-0001");
            Assert.AreEqual("C-0001", codigo.Valor);
        }
        [TestMethod]
        public void Constructor_CodigoContrato_ObtieneSiguiente()
        {
            var codigo = new CodigoContrato("C-0001");
            Assert.AreEqual("C-0002", codigo.GenerarSiguiente().Valor);
        }
    }
}
