using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class ContratoTest
    {
        [TestMethod]
        public void Constructor_NumeroContratoNull_LanzaExcepcion()
        {
            var monto = 100;
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Contrato.Crear(
                new CodigoContrato(null!),
                Guid.CreateVersion7(),
                    PeriodicidadContrato.Anual,
                monto,
                new FechaContrato(DateTime.UtcNow),
                Guid.CreateVersion7(),
                "Firma",
                new FechaContrato(DateTime.UtcNow),
                monto,
                "Pago inicial"
                ));
        }
        [TestMethod]
        public void Constructor_MontoCero_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Contrato.Crear(
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                    PeriodicidadContrato.Anual,
                0,
                new FechaContrato(DateTime.UtcNow),
                Guid.CreateVersion7(),
                "Firma",
                new FechaContrato(DateTime.UtcNow),
                100,
                "Pago inicial"
                ));
        }
        [TestMethod]
        public void Constructor_MontoMenorCero_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Contrato.Crear(
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                    PeriodicidadContrato.Anual,
                -10,
                new FechaContrato(DateTime.UtcNow),
                Guid.CreateVersion7(),
                "Firma",
                new FechaContrato(DateTime.UtcNow),
                100,
                "Pago inicial"
                ));
        }
        [TestMethod]
        public void Rehidratar_NoLanzaExcepcion()
        {
            var contrato = Contrato.Rehidratar(
                Guid.CreateVersion7(),
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                    PeriodicidadContrato.Anual,
                10,
                new FechaContrato(DateTime.UtcNow),
                DateTime.UtcNow.AddYears(10),
                Guid.CreateVersion7(),
                EstadoContrato.Activo,
                "Firma"
                );
            Assert.IsNotNull(contrato);
        }
        [TestMethod]
        public void ObtenerAniosAtrasados_Retorna4()
        {
            var fechaBase = new DateTime(2020, 1, 1);

            var contrato = Contrato.Crear(
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                    PeriodicidadContrato.Anual,
                10,
                new FechaContrato(fechaBase),
                Guid.CreateVersion7(),
                "Firma",
                new FechaContrato(DateTime.UtcNow),
                10,
                "Pago inicial"
                );
            var anios = contrato.ObtenerAniosVencidosNoPagados(new DateOnly(2024, 1, 1));
            
            Assert.AreEqual(4,anios);
        }

        [TestMethod]
        public void Crear_ContratoValido_CreaContratoConPagoInicial()
        {
            var monto = 100m;
            var contrato = Contrato.Crear(
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                PeriodicidadContrato.Anual,
                monto,
                new FechaContrato(DateTime.UtcNow),
                Guid.CreateVersion7(),
                "Observacion",
                new FechaContrato(DateTime.UtcNow),
                monto,
                "Pago inicial"
            );

            Assert.IsNotNull(contrato);
            Assert.AreEqual(1, contrato.Pagos.Count);
            Assert.AreEqual(EstadoContrato.Activo, contrato.Estado);
        }

        [TestMethod]
        public void RegistrarPago_MontoMenorOIgualCero_LanzaExcepcion()
        {
            var contrato = Contrato.Rehidratar(
                Guid.CreateVersion7(),
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                PeriodicidadContrato.Anual,
                100,
                new FechaContrato(DateTime.UtcNow),
                DateTime.UtcNow.AddYears(10),
                Guid.CreateVersion7(),
                EstadoContrato.Activo,
                "Observacion"
            );

            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => contrato.RegistrarPago(
                new FechaContrato(DateTime.UtcNow),
                0,
                EstadoConcepto.Cuota,
                "Pago cuota"
            ));
        }

        [TestMethod]
        public void RegistrarPago_AnioYaPagado_LanzaExcepcion()
        {
            var fecha = new FechaContrato(DateTime.UtcNow);
            var contrato = Contrato.Rehidratar(
                Guid.CreateVersion7(),
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                PeriodicidadContrato.Anual,
                100,
                fecha,
                DateTime.UtcNow.AddYears(10),
                Guid.CreateVersion7(),
                EstadoContrato.Activo,
                "Observacion"
            );

            // Primer pago (éxito)
            contrato.RegistrarPago(fecha, 100, EstadoConcepto.Cuota, "Pago 1");

            // Segundo pago mismo año (fallo)
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => contrato.RegistrarPago(
                fecha,
                100,
                EstadoConcepto.Cuota,
                "Pago 2"
            ));
        }

        [TestMethod]
        public void RehidratarPago_AgregaPagoALista()
        {
            var contrato = Contrato.Rehidratar(
                Guid.CreateVersion7(),
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                PeriodicidadContrato.Anual,
                100,
                new FechaContrato(DateTime.UtcNow),
                DateTime.UtcNow.AddYears(10),
                Guid.CreateVersion7(),
                EstadoContrato.Activo,
                "Observacion"
            );

            contrato.RehidratarPago(
                Guid.CreateVersion7(),
                new FechaContrato(DateTime.UtcNow),
                100,
                EstadoConcepto.Cuota,
                "Pago rehidratado"
            );

            Assert.AreEqual(1, contrato.Pagos.Count);
        }
    }
}
