using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Comandos;
using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Dtos;
using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Dominio.Repositorios;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;


namespace campo_santo_service.Pruebas.Aplicacion.CasosDeUso.Nichos
{
    [TestClass]
    public class CasoDeUsoCrearEspacioTest
    {
        private IEspacioRepository repository;
        private IValidator<CrearEspacioCommand> validator;
        private IUnidadDeTrabajo unidadDeTrabajo;
        private CrearEspacioHandler casoDeUso;

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IEspacioRepository>();
            validator = Substitute.For<IValidator<CrearEspacioCommand>>();
            unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            casoDeUso = new CrearEspacioHandler(repository, unidadDeTrabajo, validator);
        }

        [TestMethod]
        public async Task Handle_ComandoValido_ObtenemosIdNicho()
        {
            var comando = new CrearEspacioCommand { Codigo = "C-0001", Tipo = "Nicho", Piso = "PlantaBaja", Ubicacion = "Centro" };
            validator.ValidateAsync(comando).Returns(new ValidationResult());
            repository.Agregar(Arg.Any<campo_santo_service.Dominio.Entidades.Espacio>()).Returns(Task.CompletedTask);
            unidadDeTrabajo.CommitAsync().Returns(Task.CompletedTask);

            var id = await casoDeUso.Ejecutar(comando);

            Assert.AreNotEqual(Guid.Empty, id);
        }
    }
}
