using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Infraestructura.Datos.Contexto;
using Microsoft.EntityFrameworkCore;

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

        public void Reversar()
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}
