

using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Comandos;
using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.ObjetosDeValor;
using campo_santo_service.Dominio.Repositorios;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;

namespace campo_santo_service.Pruebas.Aplicacion.CasosDeUso.Nichos
{


    [TestClass]
    public class CasoDeUsoOcuparEspacioTest
    {
        private IEspacioRepository repository = null!;
        private IUnidadDeTrabajo unidadDeTrabajo = null!;
        private IValidator<OcuparEspacioCommand> validator = null!;
        private OcuparEspacioHandler casoDeUso = null!;

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IEspacioRepository>();
            unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            validator = Substitute.For<IValidator<OcuparEspacioCommand>>();
            casoDeUso = new OcuparEspacioHandler(repository, unidadDeTrabajo);
        }

        [TestMethod]
        public async Task Ejecutar_ComandoValido_OcupaEspacioYConfirma()
        {
            // Arrange
            var espacioId = Guid.NewGuid();
            var codigo = new CodigoContrato("C-0001");

            var comando = new OcuparEspacioCommand(espacioId);

            validator
                .ValidateAsync(comando)
                .Returns(Task.FromResult(new ValidationResult()));

            var espacio = Espacio.Rehidratar(
                espacioId,
                codigo,
                TipoEspacio.Nicho,
                NivelPiso.PlantaBaja,
                EstadoEspacio.Disponible,
                "Sector A"
            );

            repository
                .ObtenerPorId(espacioId)
                .Returns(Task.FromResult<Espacio?>(espacio));

            repository
                .Actualizar(Arg.Any<Espacio>())
                .Returns(Task.CompletedTask);

            unidadDeTrabajo
                .CommitAsync()
                .Returns(Task.CompletedTask);

            // Act
            await casoDeUso.Ejecutar(comando);

            // Assert (COMPORTAMIENTO)
            Assert.AreEqual(EstadoEspacio.Ocupado, espacio.Estado);

            await repository.Received(1).Actualizar(espacio);
            await unidadDeTrabajo.Received(1).CommitAsync();
            unidadDeTrabajo.DidNotReceive().Reversar();
        }
    }
}