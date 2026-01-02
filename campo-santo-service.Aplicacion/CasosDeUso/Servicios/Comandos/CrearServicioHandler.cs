using campo_santo_service.Aplicacion.CasosDeUso.Servicios.Dtos;
using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Repositorios;

namespace campo_santo_service.Aplicacion.CasosDeUso.Servicios.Comandos
{
    public class CrearServicioHandler
    {
        private readonly IServicioRepository repository;
        private readonly IUnidadDeTrabajo uow;

        public CrearServicioHandler(IServicioRepository repository, IUnidadDeTrabajo uow)
        {
            this.repository = repository;
            this.uow = uow;
        }

        public async Task<Guid> Ejecutar(CrearServicioCommand request)
        {
            var servicio = Servicio.Crear(request.nombre, request.precio);

            await repository.Agregar(servicio);

            await uow.CommitAsync();

            return servicio.Id;
        }
    }
}
