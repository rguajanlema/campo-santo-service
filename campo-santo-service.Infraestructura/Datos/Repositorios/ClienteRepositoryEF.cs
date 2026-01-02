using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.ObjetosDeValor;
using campo_santo_service.Dominio.Repositorios;
using campo_santo_service.Infraestructura.Datos.Contexto;
using campo_santo_service.Infraestructura.Modelos;
using Microsoft.EntityFrameworkCore;

namespace campo_santo_service.Infraestructura.Datos.Repositorios
{
    public class ClienteRepositoryEF : IClienteRepository
    {
        private readonly CampoSantoDbContext context;

        public ClienteRepositoryEF(CampoSantoDbContext context)
        {
            this.context = context;
        }
        public async Task Agregar(Cliente cliente)
        {
            await context.Clientes
            .AddAsync(SociosEntity.FromDomain(cliente));
        }

        public async Task<Cliente?> ObtenerPorCedula(Cedula cedula)
        {
            var entity = await context.Clientes
            .SingleOrDefaultAsync(c=>c.Cedula == cedula.Valor);
            return entity?.ToDomain();
        }

        public async Task<Cliente?> ObtenerPorContrato(string codigoContrato)
        {
            var entity = await context.Contratos
            .Include(c=>c.Cliente)
            .SingleOrDefaultAsync(c => c.Codigo == codigoContrato);
            return entity?.Cliente?.ToDomain();
        }

        public async Task<Cliente?> ObtenerPorId(Guid id)
        {
            var entity = await context.Clientes.FindAsync(id);
            return entity?.ToDomain();
        }

        public async Task<IEnumerable<Cliente>> ObtenerPorNombre(string nombre)
        {
            var entities = await context.Clientes
               .Where(x =>
                   x.Nombre.ToLower().Contains(nombre.ToLower()) ||
                   x.Apellido.ToLower().Contains(nombre.ToLower()))
               .ToListAsync();

            return entities.Select(e => e.ToDomain());
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodos()
        {
            var entities = await context.Clientes.ToArrayAsync();

            return entities.Select(e => e.ToDomain());
        }
    }
}
