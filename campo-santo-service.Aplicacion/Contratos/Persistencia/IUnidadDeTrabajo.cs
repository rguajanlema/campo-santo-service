namespace campo_santo_service.Aplicacion.Contratos.Persistencia
{
    public interface IUnidadDeTrabajo
    {
        void Reversar();
        Task CommitAsync();
    }
}
