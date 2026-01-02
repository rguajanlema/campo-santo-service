using campo_santo_service.Dominio.Entidades;

namespace campo_santo_service.Dominio.Repositorios
{
    public interface IContratoRepository
    {
        Task<Contrato?> ObtenerPorId(Guid id);
        Task Agregar(Contrato contrato);
        Task<IEnumerable<Contrato>> ObtenerTodo();
        Task<IEnumerable<Contrato>> ObtenerPorClienteId(Guid id);
        Task<Contrato?> ObtenerUltimo();
    }
}
