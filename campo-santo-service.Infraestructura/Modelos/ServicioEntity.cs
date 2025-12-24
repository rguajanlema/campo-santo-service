using campo_santo_service.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace campo_santo_service.Infraestructura.Modelos
{
    [Table("servicios")]
    public class ServicioEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; } = null!;
        [Column("precio")]
        public decimal Precio { get; set; }

        public static ServicioEntity FromDomain(Servicio domain)
        {
            return new ServicioEntity
            {
                Id = domain.Id,
                Nombre = domain.Nombre,
                Precio = domain.Precio,
            };
        }

        public Servicio ToDomain()
        {
            return Servicio.Rehidratar(Id, Nombre,Precio);
        }
    }
}
