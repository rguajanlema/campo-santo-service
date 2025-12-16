using campo_santo_service.Dominio.Entidades;

namespace campo_santo_service.Dominio.Repositorios
{
    public interface IServicioRepository
    {
        Task<Servicio?> ObtenerPorId(Guid id);
        Task Agregar(Servicio request);
        Task<IEnumerable<Servicio>> ObtenerTodo();
    }
}
