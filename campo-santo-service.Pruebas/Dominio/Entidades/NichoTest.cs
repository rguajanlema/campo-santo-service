using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Pruebas.Dominio.Entidades
{
    [TestClass]
    public class NichoTest
    {
        [TestMethod]
        public void Constructor_CodigoNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Espacio.Rehidratar(
                Guid.CreateVersion7(),
                null!,
                TipoEspacio.Boveda,
                NivelPiso.PlantaBaja,
                EstadoEspacio.Disponible,
                "Crento"
                )
            );
        }
        [TestMethod]
        public void Constructor_DireccionNull_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Espacio.Rehidratar(
                Guid.CreateVersion7(),
                new CodigoContrato("N-0001"),
                TipoEspacio.Boveda,
                NivelPiso.PlantaBaja,
                EstadoEspacio.Disponible,
                null!
                )
            );
        }
        [TestMethod]
        public void Constructor_NoLanzaExcepcion()
        {
            Espacio.Rehidratar(
                Guid.CreateVersion7(),
                new CodigoContrato("N-0001"),
                TipoEspacio.Boveda,
                NivelPiso.PlantaBaja,
                EstadoEspacio.Disponible,
                "Centro"
                );
        }
        [TestMethod]
        public void Metodo_AgregarCuartoPiso_LanzaExcepcion()
        {
            Assert.Throws<ExcepcionDeReglaDeNegocio>(() => Espacio.Rehidratar(
                Guid.CreateVersion7(),
                new CodigoContrato("N-0001"),
                TipoEspacio.Boveda,
                NivelPiso.TercerPiso,
                EstadoEspacio.Disponible,
                "Centro"
                ).AgregarPiso());
        }
        [TestMethod]
        public void Constructor_AgregarPrimerPiso_NoLanzaExcepcion()
        {
            var nicho = Espacio.Rehidratar(
                Guid.CreateVersion7(),
                new CodigoContrato("N-0001"),
                TipoEspacio.Boveda,
                NivelPiso.PrimerPiso,
                EstadoEspacio.Disponible,
                "Centro"
                );

            nicho.AgregarPiso();
            
            Assert.AreEqual(NivelPiso.SegundoPiso, nicho.Piso);
        }
    }
}
