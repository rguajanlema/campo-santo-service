namespace campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos
{
    public record ObtenerContratoQuery(
        Guid id, 
        string nombre,
        string apellido,
        string codigo,
        string cedula
        )
    {

    }
}
