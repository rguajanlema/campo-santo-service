using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.ObjetosDeValor
{
    [TestClass]
    public class FechaContratoTest
    {
        [TestMethod]
        public void Constructor_FechaNoPuedeSerMayorFechaActual_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new FechaContrato(DateTime.UtcNow.AddDays(1)));
        }
        [TestMethod]
        public void Constructor_FechaActual_LanzaExcepcion()
        {
            var fecha = new FechaContrato(DateTime.UtcNow);
            Assert.IsNotNull(fecha);
        }
        
        [TestMethod]
        public void Constructor_Fecha_NoLanzaExcepcion()
        {
            var fecha = new FechaContrato(DateTime.UtcNow.AddDays(-1));
            Assert.IsNotNull(fecha);
        }
    }
}
