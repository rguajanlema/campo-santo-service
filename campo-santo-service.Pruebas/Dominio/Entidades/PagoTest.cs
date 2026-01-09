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
        public void RegistarPago_MontoMenorCero_LanzaExcepcion()
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
        public void RegistarPago_ObservacionNull_LanzaExcepcion()
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
        public void RegistarPago_FechaMayor_LanzaExcepcion()
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
        public void RegistarPago_FechaMenor_NoLanzaExcepcion()
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
        public void RegistarPago_NoLanzaExcepcion()
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
        public void Rehidratar_NoLanzaExcepcion()
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
        [TestMethod]
        public void Rehidratar_MontoMenorCero_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Pago.Rehidratar(
                Guid.CreateVersion7(),
                Guid.CreateVersion7(),
                new FechaContrato(DateTime.UtcNow),
                -10,
                EstadoConcepto.Inicio,
                "Inicio contrato"
                ));
        }
        [TestMethod]
        public void Rehidratar_ObservacionNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Pago.Rehidratar(
                Guid.CreateVersion7(),
                Guid.CreateVersion7(),
                new FechaContrato(DateTime.UtcNow),
                10,
                EstadoConcepto.Inicio,
                null!
                ));
        }
        [TestMethod]
        public void Rehidratar_FechaMayor_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Pago.Rehidratar(
                Guid.CreateVersion7(),
                Guid.CreateVersion7(),
                new FechaContrato(DateTime.UtcNow.AddDays(1)),
                10,
                EstadoConcepto.Inicio,
                null!
                ));
        }
    }
}
