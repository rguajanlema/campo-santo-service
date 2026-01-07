using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.ObjetosDeValor
{
    [TestClass]
    public class TelefonoTest
    {
        [TestMethod]
        public void Constructor_Telefono_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Telefono(null!));
        }
        [TestMethod]
        public void Constructor_TelefonoMayorADiezDigitos_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Telefono("09811245832"));
        }
        [TestMethod]
        public void Constructor_TelefonoMenorADiezDigitos_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Telefono("0981124"));
        }
        [TestMethod]
        public void Constructor_TelefonoVacio_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Telefono(""));
        }
        [TestMethod]
        public void Constructor_Telefono_NoLanzaExcepcion()
        {
            var telefono = new Telefono("0981124583").Valor;
            Assert.IsNotNull(telefono);
        }
    }
}
