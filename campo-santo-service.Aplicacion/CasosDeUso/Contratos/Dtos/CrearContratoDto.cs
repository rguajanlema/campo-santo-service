namespace campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos
{
    public sealed class CrearContratoDto
    {
        public string Codigo { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }
        public string TipoContrato { get; set; } = null!;
        public string Observaciones { get; set; } = null!;
        public decimal Monto { get; set; }
        public Guid EspacioId { get; set; }
        public CrearFamiliarDto FamiliarDto { get; set; } = null!;
        public List<CrearPagoDto> PagoDto { get; set; } = new ();
        
    }
}
