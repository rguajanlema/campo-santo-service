namespace campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos
{
    public sealed record CrearFamiliarCommand(
        string Nombre,
        string Apellido,
        string Cedula,
        string Telefono,
        string Correo,
        string Direccion
        )
    {
    }
}
