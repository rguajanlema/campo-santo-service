using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Repositorios;
using campo_santo_service.Infraestructura.Datos.Contexto;
using campo_santo_service.Infraestructura.Modelos;
using Microsoft.EntityFrameworkCore;


namespace campo_santo_service.Infraestructura.Datos.Repositorios
{
    public class EspacioRepositoryEF : IEspacioRepository
    {
        private readonly CampoSantoDbContext context;

        public EspacioRepositoryEF(CampoSantoDbContext context)
        {
            this.context = context;
        }
        public async Task Agregar(Espacio espacio)
        {
            var entity = EspacioEntity.FromDomain(espacio);
            await context.Espacios.AddAsync(entity);
        }

        public async Task<IEnumerable<Espacio>> ObtenerLibres()
        {
            var entities = await context.Espacios
            .Where(x => x.Estado == EstadoEspacio.Disponible.ToString())
            .ToListAsync();
            var espacios = entities.Select(e => e.ToDomain());

            return espacios;
        }

        public async Task<Espacio?> ObtenerPorId(Guid id)
        {
            var entity = await context.Espacios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return entity?.ToDomain();
        }

        public async Task<IEnumerable<Espacio>> ObtenerTodo()
        {
            var entities = await context.Espacios.ToArrayAsync();
            var espacios = entities.Select(e => e.ToDomain());

            return espacios;
        }
        public Task Actualizar(Espacio espacio)
        {
            var entity = EspacioEntity.FromDomain(espacio);
            context.Espacios.Attach(entity);
            context.Entry(entity).Property(x => x.Estado).IsModified = true;
            return Task.CompletedTask;
        }

        public async Task<Espacio?> ObtenerUltimo()
        {
            var entity = await context.Espacios
            .OrderByDescending(e => e.Id)
            .FirstOrDefaultAsync();

            return entity?.ToDomain();
        }
    }
}
