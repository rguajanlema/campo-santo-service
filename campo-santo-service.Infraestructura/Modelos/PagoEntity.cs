using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
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
        public ContratoEntity Contrato { get; set; } = null!;
        public Guid ContratoId { get; set; }
        [Column("fecha_pago")]
        public DateTime FechaPago { get; set; }
        [Column("monto")]
        public decimal Monto { get; set; }
        [Column("concepto")]
        public string Concepto { get; set; } = null!;
        [Column("observaciones")]
        public string Observacion { get; set; } = null!;

        public static PagoEntity FromDomain(Pago pago)
        {
            return new PagoEntity
            {
                Id = pago.Id,
                ContratoId = pago.ContratoId,
                FechaPago = pago.FechaPago.Valor,
                Monto = pago.Monto,
                Concepto = pago.Concepto.ToString(),
                Observacion = pago.Observacion
            };
        }
        public Pago ToDomain()
        {
            return Pago.Rehidratar(
                Id,
                ContratoId,
                new Dominio.ObjetosDeValor.FechaContrato(FechaPago),
                Monto,
                Enum.Parse<EstadoConceptos>(Concepto),
                Observacion
                );
        }
    }
}
