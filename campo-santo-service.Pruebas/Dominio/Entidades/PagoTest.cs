using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class PagoTest
    {
        [TestMethod]
        public void Constructor_MontoMenorCero_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Pago.RegistarPago(
                Guid.CreateVersion7(),
                new FechaContrato(DateTime.UtcNow),
                -10,
                EstadoConcepto.Inicio,
                "Inicio contrato"
                ));
        }
        [TestMethod]
        public void Constructor_ObservacionNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Pago.RegistarPago(
                Guid.CreateVersion7(),
                new FechaContrato(DateTime.UtcNow),
                10,
                EstadoConcepto.Inicio,
                null!
                ));
        }
        [TestMethod]
        public void Constructor_FechaMayor_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Pago.RegistarPago(
                Guid.CreateVersion7(),
                new FechaContrato(DateTime.UtcNow.AddDays(1)),
                10,
                EstadoConcepto.Inicio,
                null!
                ));
        }
        [TestMethod]
        public void Constructor_FechaMenor_NoLanzaExcepcion()
        {
            Pago.RegistarPago(
                Guid.CreateVersion7(),
                new FechaContrato(DateTime.UtcNow.AddDays(-11)),
                10,
                EstadoConcepto.Inicio,
                "Finaliza contrato"
                );
        }

        [TestMethod]
        public void Constructor_NoLanzaExcepcion()
        {
            Pago.RegistarPago(
                Guid.CreateVersion7(),
                new FechaContrato(DateTime.UtcNow),
                10,
                EstadoConcepto.Inicio,
                "Inicio contrato"
                );
        }
        [TestMethod]
        public void Constructor_Refrescar_NoLanzaExcepcion()
        {
            Pago.Rehidratar(
                Guid.CreateVersion7(),
                Guid.CreateVersion7(),
                new FechaContrato(DateTime.UtcNow),
                10,
                EstadoConcepto.Inicio,
                "Inicio contrato"
                );
        }
    }
}
