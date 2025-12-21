using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Repositorios;
using campo_santo_service.Infraestructura.Datos.Contexto;
using campo_santo_service.Infraestructura.Modelos;
using Microsoft.EntityFrameworkCore;

namespace campo_santo_service.Infraestructura.Datos.Repositorios
{
    public class ContratoRepositoryEF : IContratoRepository
    {
        private readonly CampoSantoDbContext context;

        public ContratoRepositoryEF(CampoSantoDbContext context)
        {
            this.context = context;
        }
        public async Task Agregar(Contrato contrato)
        {
            await context.Contratos.AddAsync(ContratoEntity.FromDomain(contrato));
        }

        public async Task<Contrato?> ObtenerPorId(Guid id)
        {
            var entity = await context.Contratos.FindAsync(id);
            return entity?.ToDomain();
        }

        public async Task<IEnumerable<Contrato>> ObtenerTodo()
        {
            var entities = await context.Contratos.ToArrayAsync();
            var contratos = entities.Select(e => e.ToDomain());

            return contratos;
        }
    }
}
