using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Infraestructura.Datos.Contexto;

namespace campo_santo_service.Infraestructura.Datos.UnitOfWork
{
    public class UnitOfWorkEF : IUnidadDeTrabajo
    {
        private readonly CampoSantoDbContext context;

        public UnitOfWorkEF(CampoSantoDbContext context)
        {
            this.context = context;
        }
        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public Task Persistir()
        {
            throw new NotImplementedException();
        }

        public Task Reversar()
        {
            throw new NotImplementedException();
        }
    }
}
