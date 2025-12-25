using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.ObjetosDeValor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace campo_santo_service.Infraestructura.Modelos
{
    [Table("contratos")]
    public class ContratoEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("codigo")]
        public string Codigo { get; set; } = null!;
        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; }
        [Column("fecha_fin")]
        public DateTime FechaFin { get; set; }
        [Column("tipo_contrato")]
        public string TipoContrato { get; set; } = null!;

        [Column("estado")]
        public string Estado {  get; set; } = null!;
        [Column("observaciones")]
        public string Observaciones { get; set; } = null!;
        [Column("monto")]
        public decimal Monto { get; set; }

        [Column("cliente_id")]
        public Guid ClienteId { get; set; }
        [ForeignKey(nameof(ClienteId))]
        public ClienteEntity Cliente { get; set; } = null!;

        [Column("espacio_id")]
        public Guid EspacioId { get; set; }
        public ICollection<PagoEntity> Pagos { get; set; } = new List<PagoEntity>();

        public static ContratoEntity FromDomain(Contrato contrato)
        {
            return new ContratoEntity
            {
                Id = contrato.Id,
                Codigo = contrato.Codigo.Valor,
                FechaInicio = contrato.FechaInicio.Valor,
                FechaFin = contrato.FechaFinaliza,
                TipoContrato = contrato.Tipo.ToString(),
                Estado = contrato.Estado.ToString(),
                Observaciones = contrato.Observacion,
                Monto = contrato.Monto,
                ClienteId = contrato.ClienteId,
                EspacioId = contrato.EspacioId,
                Pagos = contrato.Pagos
                .Select(p => new PagoEntity
                {
                    Id = p.Id,
                    ContratoId = contrato.Id,
                    FechaPago = p.FechaPago.Valor,
                    Monto = p.Monto,
                    Concepto = p.Concepto.ToString(),
                    Observacion = p.Observacion
                })
                .ToList()

            };
        }
        public Contrato ToDomain()
        {
            var contrato = Contrato.Reidratar(
                Id,
                new CodigoContrato(Codigo),
                ClienteId,
                Enum.Parse<EnumContrato>(TipoContrato),
                Monto,
                new FechaContrato(FechaInicio),
                FechaFin,
                EspacioId,
                Enum.Parse<EstadoContrato>(Estado),
                Observaciones
                );
            foreach (var pago in Pagos)
            {
                contrato.RehidratarPago(
                    pago.Id,
                    new FechaContrato(pago.FechaPago),
                    pago.Monto,
                    Enum.Parse<EstadoConceptos>(pago.Concepto),
                    pago.Observacion
                );
            }

            return contrato;
        }
    }
}
