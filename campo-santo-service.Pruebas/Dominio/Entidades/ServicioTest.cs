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
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Servicio.Agregar(
                null!,
                10
                )
            );
        }
        [TestMethod]
        public void Constructor_PrecioMenorCero_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Servicio.Agregar(
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
            Servicio.Agregar(
                "Exumancion",
                20
                );
        }
    }
}
