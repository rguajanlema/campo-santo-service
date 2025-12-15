using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace campo_santo_service.Infraestructura.Modelos
{
    [Table("espacios")]
    public class EspacioEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("codigo")]
        public string Codigo { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        [Column("piso")]
        public string Piso { get; set; } = null!;
        [Column("estado")]
        public string Estado { get; set; } = null!;
        [Column("ubicacion")]
        public string Ubicacion {  get; set; } = null!;

        public static EspacioEntity FromDomain(Espacio espacio)
        {
            return new EspacioEntity
            {
                Id = espacio.Id,
                Codigo = espacio.Codigo.Valor,
                Tipo = espacio.Tipo.ToString(),
                Piso = espacio.Piso.ToString(),
                Estado = espacio.Estado.ToString(),
                Ubicacion = espacio.Ubicacion,
            };
        }
        public Espacio ToDomain()
        {
            return Espacio.Rehidratar(
                Id,
                new Dominio.ObjetosDeValor.CodigoContrato(Codigo),
                Enum.Parse<EstadoTipo>(Tipo),
                Enum.Parse<NivelesPiso>(Piso),
                Enum.Parse<EstadoEspacio>(Estado),
                Ubicacion
                );
        }
    }
}
