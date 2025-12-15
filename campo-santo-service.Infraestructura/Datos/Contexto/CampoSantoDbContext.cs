using campo_santo_service.Infraestructura.Modelos;
using Microsoft.EntityFrameworkCore;


namespace campo_santo_service.Infraestructura.Datos.Contexto
{
    public class CampoSantoDbContext : DbContext
    {
        public DbSet<EspacioEntity> Espacios => Set<EspacioEntity>();
        public CampoSantoDbContext(DbContextOptions<CampoSantoDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<EspacioEntity>(entity =>
            {
                entity.ToTable("espacios");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.Codigo)
                      .HasColumnName("codigo");

                entity.Property(e => e.Estado)
                      .HasColumnName("estado");

                entity.Property(e => e.Tipo)
                      .HasColumnName("tipo");

                entity.Property(e => e.Ubicacion)
                      .HasColumnName("ubicacion");
            });
        }

    }
}
