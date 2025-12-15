using campo_santo_service.Dominio.Entidades;
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

        public async Task<Espacio?> ObtenerPorId(Guid id)
        {
            var entity = await context.Espacios.FindAsync(id);
            return entity?.ToDomain();
        }

        public async Task<IEnumerable<Espacio>> ObtenerTodo()
        {
            var entities = await context.Espacios.ToArrayAsync();
            var espacios = entities.Select(e => e.ToDomain());

            return espacios;
        }
    }
}
