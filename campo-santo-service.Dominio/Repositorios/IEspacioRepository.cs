using campo_santo_service.Dominio.Entidades;

namespace campo_santo_service.Dominio.Repositorios
{
    public interface IEspacioRepository
    {
        Task<Espacio?> ObtenerPorId(Guid id);
        Task Agregar(Espacio espacio);
        Task<IEnumerable<Espacio>> ObtenerTodo();
        Task<IEnumerable<Espacio>> ObtenerLibres();
    }
}
