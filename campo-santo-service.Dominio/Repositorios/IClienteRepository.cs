using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Dominio.Repositorios
{
    public interface IClienteRepository
    {
        Task<Cliente?> ObtenerPorId(Guid id);
        Task Agregar(Cliente espacio);
        Task<Cliente?> ObtenerPorCedula(Cedula cedula);
        Task<IEnumerable<Cliente>> ObtenerPorNombre(string nombre);
        Task<Cliente?> ObtenerPorContrato(string codigoContrato);
        Task<IEnumerable<Cliente>> ObtenerTodos();
    }
}
