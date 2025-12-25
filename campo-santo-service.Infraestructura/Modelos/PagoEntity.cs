using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace campo_santo_service.Infraestructura.Modelos
{
    [Table("pagos")]
    public class PagoEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("contrato_id")]
        public Guid ContratoId { get; set; }
        public ContratoEntity Contrato { get; set; } = null!;

        [Column("fecha_pago")]
        public DateTime FechaPago { get; set; }
        [Column("monto")]
        public decimal Monto { get; set; }
        [Column("concepto")]
        public string Concepto { get; set; } = null!;
        [Column("observaciones")]
        public string Observacion { get; set; } = null!;

    }
}
