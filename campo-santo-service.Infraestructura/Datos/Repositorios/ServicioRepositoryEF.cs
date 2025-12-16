using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Repositorios;
using campo_santo_service.Infraestructura.Datos.Contexto;
using campo_santo_service.Infraestructura.Modelos;
using Microsoft.EntityFrameworkCore;


namespace campo_santo_service.Infraestructura.Datos.Repositorios
{
    public class ServicioRepositoryEF : IServicioRepository
    {
        private readonly CampoSantoDbContext context;

        public ServicioRepositoryEF(CampoSantoDbContext context)
        {
            this.context = context;
        }
        public async Task Agregar(Servicio request)
        {
            var entity = ServicioEntity.FromDomain(request);
            await context.Servicios.AddAsync(entity);
        }

        public async Task<Servicio?> ObtenerPorId(Guid id)
        {
            var entity = await context.Servicios.FindAsync(id);
            return entity?.ToDomain();
        }

        public async Task<IEnumerable<Servicio>> ObtenerTodo()
        {
            var entities = await context.Servicios.ToArrayAsync();
            var servicios = entities.Select(e => e.ToDomain());

            return servicios;
        }
    }
}
