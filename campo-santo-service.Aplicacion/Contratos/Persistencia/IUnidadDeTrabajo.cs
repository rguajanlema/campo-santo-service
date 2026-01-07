namespace campo_santo_service.Aplicacion.Contratos.Persistencia
{
    public interface IUnidadDeTrabajo
    {
        Task Persistir();
        void Reversar();
        Task CommitAsync();
    }
}
