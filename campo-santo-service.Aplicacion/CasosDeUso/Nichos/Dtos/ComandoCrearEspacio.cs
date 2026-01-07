namespace campo_santo_service.Aplicacion.CasosDeUso.Nichos.Dtos
{
    public sealed class ComandoCrearEspacio
    {
        public string Codigo { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Piso { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
    }
}
