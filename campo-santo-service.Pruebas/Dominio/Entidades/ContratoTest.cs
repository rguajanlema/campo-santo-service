using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class ContratoTest
    {
        [TestMethod]
        public void Constructor_NumeroContratoNull_LanzaExcepcio()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Contrato(
                null!,
                Guid.CreateVersion7(),
                Guid.CreateVersion7(),
                EnumContrato.Anual,
                100,
                Guid.CreateVersion7()
                ));
        }
        [TestMethod]
        public void Constructor_MontoCero_LanzaExcepcio()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Contrato(
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                Guid.CreateVersion7(),
                EnumContrato.Anual,
                0,
                Guid.CreateVersion7()
                ));
        }
        [TestMethod]
        public void Constructor_MontoMenorCero_LanzaExcepcio()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Contrato(
                new CodigoContrato("C-0001"),
                Guid.CreateVersion7(),
                Guid.CreateVersion7(),
                EnumContrato.Anual,
                -10,
                Guid.CreateVersion7()
                ));
        }
    }
}
