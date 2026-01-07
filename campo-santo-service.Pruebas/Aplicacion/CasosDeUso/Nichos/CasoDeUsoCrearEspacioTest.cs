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
        private IValidator<ComandoCrearEspacio> validator;
        private IUnidadDeTrabajo unidadDeTrabajo;
        private CrearEspacioHandler casoDeUso;

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IEspacioRepository>();
            validator = Substitute.For<IValidator<ComandoCrearEspacio>>();
            unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            casoDeUso = Substitute.For<CrearEspacioHandler>();
        }

        [TestMethod]
        public async Task Handle_ComandoValido_ObtenemosIdNicho()
        {
            var comando = new ComandoCrearEspacio { Codigo = "000-1" };
            validator.ValidateAsync(comando).Returns(new ValidationResult());
        }
    }
}
