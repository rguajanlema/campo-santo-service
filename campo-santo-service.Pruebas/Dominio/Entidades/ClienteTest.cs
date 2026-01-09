using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void Crear_NombreNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Cliente.Crear(
                null!,
                "Cardenas",
                "Otavalo",
                new Cedula("100000000-0"),
                new Email("cardenas@gmail.com"),
                new Telefono("0000000000")
                )
            );
        }
        [TestMethod]
        public void Crear_ApellidoNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Cliente.Crear(
                "Cristian",
                null!,
                "Otavalo",
                new Cedula("100000000-0"),
                new Email("cardenas@gmail.com"),
                new Telefono("0000000000")
                )
            );
        }
        [TestMethod]
        public void Crear_DireccionNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Cliente.Crear(
                "Cristian",
                "Yamberla",
                null!,
                new Cedula("100000000-0"),
                new Email("cardenas@gmail.com"),
                new Telefono("0000000000")
                )
            );
        }
        [TestMethod]
        public void Crear_CelulaNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Cliente.Crear(
                "Cristian",
                "Yamberla",
                "Quito",
                null!,
                new Email("cardenas@gmail.com"),
                new Telefono("0000000000")
                )
            );
        }
        [TestMethod]
        public void Crear_EmailNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Cliente.Crear(
                "Cristian",
                "Yamberla",
                "Quito",
                new Cedula("100000000-0"),
                null!,
                new Telefono("0000000000")
                )
            );
        }
        [TestMethod]
        public void Crear_TelefonoNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Cliente.Crear(
                "Cristian",
                "Yamberla",
                "Quito",
                new Cedula("100000000-0"),
                new Email("cardenas@gmail.com"),
                null!
                )
            );
        }
        [TestMethod]
        public void Crear_DatosValidos_NoLanzaExcepcion()
        {
            Cliente.Crear(
                "Cristian",
                "Yamberla",
                "Quito",
                new Cedula("100000000-0"),
                new Email("cardenas@gmail.com"),
                new Telefono("0000000000")
                );
        }

        [TestMethod]
        public void Rehidratar_DatosValidos_RetornaCliente()
        {
            var cliente = Cliente.Rehidratar(
                Guid.CreateVersion7(),
                "Cristian",
                "Yamberla",
                "Quito",
                new Cedula("100000000-0"),
                new Email("cardenas@gmail.com"),
                new Telefono("0000000000")
            );
            Assert.IsNotNull(cliente);
        }

        [TestMethod]
        public void RegistrarContrato_ContratoValido_AgregaContrato()
        {
            var clienteId = Guid.CreateVersion7();
            var cliente = Cliente.Rehidratar(
                clienteId,
                "Cristian",
                "Yamberla",
                "Quito",
                new Cedula("100000000-0"),
                new Email("cardenas@gmail.com"),
                new Telefono("0000000000")
            );

            var contrato = Contrato.Rehidratar(
                Guid.CreateVersion7(),
                new CodigoContrato("C-0001"),
                clienteId,
                PeriodicidadContrato.Anual,
                100,
                new FechaContrato(DateTime.UtcNow),
                DateTime.UtcNow.AddYears(1),
                Guid.CreateVersion7(),
                EstadoContrato.Activo,
                "Obs"
            );

            cliente.RegistrarContrato(contrato);

            Assert.AreEqual(1, cliente.Contratos.Count);
        }

        [TestMethod]
        public void RegistrarContrato_ContratoDeOtroCliente_LanzaExcepcion()
        {
            var clienteId = Guid.CreateVersion7();
            var otroClienteId = Guid.CreateVersion7();
            
            var cliente = Cliente.Rehidratar(
                clienteId,
                "Cristian",
                "Yamberla",
                "Quito",
                new Cedula("100000000-0"),
                new Email("cardenas@gmail.com"),
                new Telefono("0000000000")
            );

            var contrato = Contrato.Rehidratar(
                Guid.CreateVersion7(),
                new CodigoContrato("C-0001"),
                otroClienteId, // ID diferente
                PeriodicidadContrato.Anual,
                100,
                new FechaContrato(DateTime.UtcNow),
                DateTime.UtcNow.AddYears(1),
                Guid.CreateVersion7(),
                EstadoContrato.Activo,
                "Obs"
            );

            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => cliente.RegistrarContrato(contrato));
        }

        [TestMethod]
        public void RehidratarContrato_AgregaContratoALista()
        {
            var clienteId = Guid.CreateVersion7();
            var cliente = Cliente.Rehidratar(
                clienteId,
                "Cristian",
                "Yamberla",
                "Quito",
                new Cedula("100000000-0"),
                new Email("cardenas@gmail.com"),
                new Telefono("0000000000")
            );

            var contrato = Contrato.Rehidratar(
                Guid.CreateVersion7(),
                new CodigoContrato("C-0010"),
                clienteId,
                PeriodicidadContrato.Anual,
                100,
                new FechaContrato(DateTime.UtcNow),
                DateTime.UtcNow.AddYears(1),
                Guid.CreateVersion7(),
                EstadoContrato.Activo,
                "Obs"
            );

            cliente.RehidratarContrato(contrato);

            Assert.AreEqual(1, cliente.Contratos.Count);
        }
    }
}
