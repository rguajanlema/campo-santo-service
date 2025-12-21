using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Pruebas.ObjetosDeValor
{
    [TestClass]
    public class FechaContratoTest
    {
        [TestMethod]
        public void Constructor_FechaNoPuedeSerMayorFechaActual_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Fecha(DateTime.UtcNow.AddDays(1)));
        }
        
        [TestMethod]
        public void Constructor_Fecha_NoLanzaExcepcion()
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
