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
        public void Constructor_NombreNull_LanzaExcepcion()
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
        public void Constructor_ApellidoNull_LanzaExcepcion()
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
        public void Constructor_DireccionNull_LanzaExcepcion()
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
        public void Constructor_CelulaNull_LanzaExcepcion()
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
        public void Constructor_EmailNull_LanzaExcepcion()
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
        public void Constructor_TelefonoNull_LanzaExcepcion()
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
        public void Constructor_NoLanzaExcepcion()
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
    }
}
