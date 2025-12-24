using campo_santo_service.Infraestructura.Modelos;
using Microsoft.EntityFrameworkCore;


namespace campo_santo_service.Infraestructura.Datos.Contexto
{
    public class CampoSantoDbContext : DbContext
    {
        public DbSet<EspacioEntity> Espacios => Set<EspacioEntity>();
        public DbSet<ServicioEntity> Servicios => Set<ServicioEntity>();
        public DbSet<PagoEntity> Pagos => Set<PagoEntity>();
        public DbSet<ContratoEntity> Contratos => Set<ContratoEntity>();
        public DbSet<ClienteEntity> Clientes => Set<ClienteEntity>();

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

            modelBuilder.Entity<ContratoEntity>()
            .HasMany(c => c.Pagos)
            .WithOne(p => p.Contrato)
            .HasForeignKey(p => p.ContratoId)
            .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
