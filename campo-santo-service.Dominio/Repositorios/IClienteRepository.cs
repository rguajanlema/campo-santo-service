using campo_santo_service.Dominio.Entidades;

namespace campo_santo_service.Dominio.Repositorios
{
    public interface IClienteRepository
    {
        Task<Cliente?> ObtenerPorId(Guid id);
        Task Agregar(Cliente espacio);
    }
}
