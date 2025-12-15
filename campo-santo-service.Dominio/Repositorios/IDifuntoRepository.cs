using campo_santo_service.Dominio.Entidades;

namespace campo_santo_service.Dominio.Repositorios
{
    public interface IDifuntoRepository
    {
        Task<IEnumerable<Difunto>> ObtenerTodo();
    }
}
