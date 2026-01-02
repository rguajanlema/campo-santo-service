namespace campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos
{
    public sealed record CrearPagoInicialCommand(
        DateTime FechaPago,
        decimal Monto,
        string Observaciones
        )
    {
    }
}
