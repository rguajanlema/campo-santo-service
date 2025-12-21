namespace campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos
{
    public sealed class CrearFamiliarDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
    }
}
