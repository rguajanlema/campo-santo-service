namespace campo_santo_service.Aplicacion.Contratos.Persistencia
{
    public interface IUnidadDeTrabajo
    {
        Task Persistir();
        Task Reversar();
        Task CommitAsync();
    }
}
