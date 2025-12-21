namespace campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos
{
    public sealed class CrearPagoDto
    {
        public DateOnly FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; } = null!;
        public string Observaciones { get; set; } = null!;
    }
}
