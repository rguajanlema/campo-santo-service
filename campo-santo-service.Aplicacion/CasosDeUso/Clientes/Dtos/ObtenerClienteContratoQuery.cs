namespace campo_santo_service.Aplicacion.CasosDeUso.Clientes.Dtos
{
    public class ObtenerClienteContratoQuery 
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; } = null!;
    }
}
