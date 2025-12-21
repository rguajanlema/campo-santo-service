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
            Servicio.Actualizar(
                Guid.CreateVersion7(),
                "Exumancion",
                100
                );
        }
        [TestMethod]
        public void Constructor_NoLanzaExcepcion()
        {
            Servicio.Crear(
                "Exumancion",
                20
                );
        }
    }
}
