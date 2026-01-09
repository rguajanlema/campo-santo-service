using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Consultas;
using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.ObjetosDeValor;
using campo_santo_service.Dominio.Repositorios;

using NSubstitute;

namespace campo_santo_service.Pruebas.Aplicacion.CasosDeUso.Nichos
{


    [TestClass]
    public class CasoDeUsoTodosEspacioTest
    {
        private IEspacioRepository repository = null!;
        private TodosEspacioHandler casoDeUso = null!;

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IEspacioRepository>();
            casoDeUso = new TodosEspacioHandler(repository);
        }

        [TestMethod]
        public async Task Ejecutar_CuandoHayEspacios_RetornaListaMapeada()
        {
            // Arrange
            var espacios = new List<Espacio>
    {
        Espacio.Rehidratar(
            Guid.NewGuid(),
            new CodigoContrato("C-0001"),
            TipoEspacio.Nicho,
            NivelPiso.PlantaBaja,
            EstadoEspacio.Disponible,
            "Sector A"
        ),
        Espacio.Rehidratar(
            Guid.NewGuid(),
            new CodigoContrato("C-0002"),
            TipoEspacio.Nicho,
            NivelPiso.PrimerPiso,
            EstadoEspacio.Ocupado,
            "Sector B"
        )
    };

            repository
                .ObtenerTodo()
                .Returns(Task.FromResult<IEnumerable<Espacio>>(espacios));

            // Act
            var resultado = (await casoDeUso.Ejecutar()).ToList();

            // Assert (COMPORTAMIENTO)
            Assert.AreEqual(2, resultado.Count);

            Assert.AreEqual("C-0001", resultado[0].Codigo);
            Assert.AreEqual("Nicho", resultado[0].Tipo);
            Assert.AreEqual("PlantaBaja", resultado[0].Piso);
            Assert.AreEqual("Disponible", resultado[0].Estado);
            Assert.AreEqual("Sector A", resultado[0].Ubicacion);

            Assert.AreEqual("C-0002", resultado[1].Codigo);
            Assert.AreEqual("Nicho", resultado[1].Tipo);
            Assert.AreEqual("PrimerPiso", resultado[1].Piso);

            Assert.AreEqual("Ocupado", resultado[1].Estado);
            Assert.AreEqual("Sector B", resultado[1].Ubicacion);

            await repository.Received(1).ObtenerTodo();
        }

    }
}