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
        [Column("tipo_concepto")]
        public string TipoConcepto { get; set; } = null!;

        [Column("estado")]
        public string Estado {  get; set; } = null!;
        [Column("observaciones")]
        public string Observaciones { get; set; } = null!;
        [Column("monto")]
        public decimal Monto { get; set; }
        [Column("cliente_id")]
        public Guid ClienteId { get; set; }
        [Column("espacio_id")]
        public Guid EspacioId { get; set; }

        public static ContratoEntity FromDomain(Contrato contrato)
        {
            return new ContratoEntity
            {
                Id = contrato.Id,
                Codigo = contrato.Codigo.Valor,
                FechaInicio = contrato.FechaInicio.Valor,
                FechaFin = contrato.FechaFinaliza,
                TipoConcepto = contrato.Tipo.ToString(),
                Estado = contrato.Estado,
                Observaciones = contrato.Observacion,
                Monto = contrato.Monto,
                ClienteId = contrato.ClienteId,
                EspacioId = contrato.EspacioId,
            };
        }
        public Contrato ToDomain()
        {
            return Contrato.Reidratar(
                Id,
                new CodigoContrato(Codigo),
                ClienteId,
                Enum.Parse<EnumContrato>(TipoConcepto),
                Monto,
                new FechaContrato(FechaInicio),
                FechaFin,
                EspacioId,
                Estado,
                Observaciones
                );
        }
    }
}
