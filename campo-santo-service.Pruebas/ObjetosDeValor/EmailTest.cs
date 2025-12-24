using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.ObjetosDeValor
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void Constructor_Email_LanzaException()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Email(null!));
        }

        [TestMethod]
        public void Constructor_EmailSinArroba_LanzaException()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Email("roberto.com"));
        }
        [TestMethod]
        public void Constructor_EmailBasio_LanzaException()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Email(""));
        }
        [TestMethod]
        public void Constructor_EmailValido_NoLanzaException()
        {
            var email = new Email("roberto@ejemplo.com").Valor;
            Assert.IsNotNull(email);
        }
    }
}
