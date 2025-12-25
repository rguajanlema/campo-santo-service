namespace campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos
{
    public sealed record CrearContratoCommand(
        string Codigo,
        DateTime FechaInicio,
        DateTime FechaFin,
        string TipoContrato,
        string Observaciones,
        decimal Monto,
        Guid EspacioId,
        CrearFamiliarCommand Familiar,
        CrearPagoInicialCommand PagoInicial
        )
    {
    }
}
