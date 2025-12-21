using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Repositorios;
using campo_santo_service.Infraestructura.Datos.Contexto;
using campo_santo_service.Infraestructura.Modelos;

namespace campo_santo_service.Infraestructura.Datos.Repositorios
{
    public class PagoRepositoryEF : IPagoRepository
    {
        private readonly CampoSantoDbContext context;

        public PagoRepositoryEF(CampoSantoDbContext context)
        {
            this.context = context;
        }

        public async Task Agregar(Pago pago)
        {
            await context.Pagos.AddAsync(PagoEntity.FromDomain(pago));
        }

        public async Task<Pago?> ObtenerPorId(Guid id)
        {
            var entity = await context.Pagos.FindAsync(id);
            return entity?.ToDomain();
        }
    }
}
