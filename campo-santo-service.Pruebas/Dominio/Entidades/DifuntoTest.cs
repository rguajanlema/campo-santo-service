using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class DifuntoTest
    {
        [TestMethod]
        public void Constructor_NombreNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Difunto(
                null!,
                "Cardenas",
                Genero.Femenino,
                new Cedula("100000000-0"),
                new FechaNacimiento(DateTime.UtcNow.AddDays(-10)),
                new FechaNacimiento(DateTime.UtcNow.AddDays(-1))
                )
            );
        }
        [TestMethod]
        public void Constructor_ApellidoNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Difunto(
                "Cristian",
                null!,
                Genero.Femenino,
                new Cedula("100000000-0"),
                new FechaNacimiento(DateTime.UtcNow.AddDays(-10)),
                new FechaNacimiento(DateTime.UtcNow.AddDays(-1))
                )
            );
        }
        [TestMethod]
        public void Constructor_CelulaNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Difunto(
                "Cristian",
                "Yamberla",
                Genero.Femenino,
                null!,
                new FechaNacimiento(DateTime.UtcNow.AddDays(-10)),
                new FechaNacimiento(DateTime.UtcNow.AddDays(-1))
                )
            );
        }
        [TestMethod]
        public void Constructor_FechaNacimientoNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Difunto(
                "Cristian",
                "Yamberla",
                Genero.Femenino,
                new Cedula("100000000-0"),
                null!,
                new FechaNacimiento(DateTime.UtcNow.AddDays(-1))
                )
            );
        }
        [TestMethod]
        public void Constructor_FechaFallecimientoNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => new Difunto(
                "Cristian",
                "Yamberla",
                Genero.Femenino,
                new Cedula("100000000-0"),
                new FechaNacimiento(DateTime.UtcNow.AddDays(-10)),
                null!
                )
            );
        }
        [TestMethod]
        public void Constructor_NoLanzaExcepcion()
        {
            var difunto = new Difunto(
                "Jose",
                "Yamberla",
                Genero.Femenino,
                new Cedula("100000000-0"),
                new FechaNacimiento(DateTime.UtcNow.AddDays(-10)),
                new FechaNacimiento(DateTime.UtcNow.AddDays(-1))
                );
            Assert.IsNotNull(difunto);
        }
    }
}
