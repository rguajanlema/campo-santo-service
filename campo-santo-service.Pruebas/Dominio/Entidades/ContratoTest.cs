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
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Contrato.Crear(
                new CodigoContrato(null!),
                Guid.CreateVersion7(),
                EnumContrato.Anual,
                100,
                new FechaContrato(DateTime.UtcNow),
                Guid.CreateVersion7(),
                EstadoContrato.Activo,
                "Firma"
                ));
        }
        [TestMethod]
        public void Constructor_MontoCero_LanzaExcepcio()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Contrato.Crear(
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                EnumContrato.Anual,
                0,
                new FechaContrato(DateTime.UtcNow),
                Guid.CreateVersion7(),
                EstadoContrato.Activo,
                "Firma"
                ));
        }
        [TestMethod]
        public void Constructor_MontoMenorCero_LanzaExcepcio()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Contrato.Crear(
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                EnumContrato.Anual,
                -10,
                new FechaContrato(DateTime.UtcNow),
                Guid.CreateVersion7(),
                EstadoContrato.Activo,
                "Firma"
                ));
        }
    }
}
