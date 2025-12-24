using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Excepciones;


namespace campo_santo_service.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class ServicioTest
    {
        [TestMethod]
        public void Constructor_NombreNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Servicio.Crear(
                null!,
                10
                )
            );
        }
        [TestMethod]
        public void Constructor_PrecioMenorCero_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Servicio.Crear(
                "Exumancion",
                -10
                )
            );
        }
        [TestMethod]
        public void Constructor_Actualizar_NoLanzaExcepcion()
        {
            var servicio = Servicio.Actualizar(
                Guid.CreateVersion7(),
                "Exumancion",
                100
                );
            Assert.IsNotNull(servicio);
        }
        [TestMethod]
        public void Constructor_NoLanzaExcepcion()
        {
            var servicio = Servicio.Crear(
                "Exumancion",
                20
                );
            Assert.IsNotNull(servicio);
        }
        [TestMethod]
        [Description("Verifica que la entidad Servicio se reconstruya correctamente desde datos persistidos")]
        public void Rehidratar_NoLanzaExcepcion()
        {
            var servicio = Servicio.Rehidratar(
                Guid.CreateVersion7(),
                "Exumancion",
                20
                );
            Assert.IsNotNull(servicio);
        }
    }
}
