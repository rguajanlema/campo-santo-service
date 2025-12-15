using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.ObjetosDeValor
{
    [TestClass]
    public class FechaNacimientoTest
    {
        [TestMethod]
        public void Constructor_FechaNacimientoNoPuedeSerMayorFechaActual_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Fecha(DateTime.UtcNow.AddDays(1)));
        }
        [TestMethod]
        public void Constructor_FechaNacimientoNoPuedeSerIgualFechaActual_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Fecha(DateTime.UtcNow));
        }
        [TestMethod]
        public void Constructor_FechaNacimiento_NoLanzaExcepcion()
        {
            try
            {
                new Fecha(DateTime.UtcNow.AddDays(-1));
            }
            catch
            {
                Assert.Fail("No debe lanzar excepciones.");
            }
        }
    }
}
