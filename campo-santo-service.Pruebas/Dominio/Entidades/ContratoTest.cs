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
        public void Constructor_NumeroContratoNull_LanzaExcepcio()
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
        public void Constructor_MontoCero_LanzaExcepcio()
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
        public void Constructor_MontoMenorCero_LanzaExcepcio()
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
        public void Rehidratar_NoLanzaExcepcio()
        {
            var contrato = Contrato.Reidratar(
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
    }
}
