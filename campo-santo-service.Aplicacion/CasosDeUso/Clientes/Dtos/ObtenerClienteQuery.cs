namespace campo_santo_service.Aplicacion.CasosDeUso.Clientes.Dtos
{
    public class ObtenerClienteQuery
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
    }
}
