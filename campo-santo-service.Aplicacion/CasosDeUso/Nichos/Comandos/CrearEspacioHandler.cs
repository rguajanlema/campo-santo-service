using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Dtos;
using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Aplicacion.Excepciones;
using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.ObjetosDeValor;
using campo_santo_service.Dominio.Repositorios;
using FluentValidation;

namespace campo_santo_service.Aplicacion.CasosDeUso.Nichos.Comandos
{
    public class CrearEspacioHandler
    {
        private readonly IEspacioRepository repository;
        private readonly IUnidadDeTrabajo uow;
        private readonly IValidator<ComandoCrearEspacio> validador;

        public CrearEspacioHandler(IEspacioRepository repository, IUnidadDeTrabajo uow,
            IValidator<ComandoCrearEspacio> validador)
        {
            this.repository = repository;
            this.uow = uow;
            this.validador = validador;
        }
        public async Task<Guid> Ejecutar(ComandoCrearEspacio dto)
        {
            var resultadoValidacion = await validador.ValidateAsync(dto);

            if (!resultadoValidacion.IsValid)
            {
                throw new ExcepcionDeValidacion(resultadoValidacion);
            }

            try
            {
                var espacio = Espacio.Crear(
                new CodigoContrato(dto.Codigo),
                Enum.Parse<EstadoTipo>(dto.Tipo),
                Enum.Parse<NivelesPiso>(dto.Piso),
                dto.Ubicacion
            );

                await repository.Agregar(espacio);

                await uow.CommitAsync();

                return espacio.Id;
            }
            catch (Exception)
            {
                await uow.Reversar();
                throw;
            }
        }
    }
}
