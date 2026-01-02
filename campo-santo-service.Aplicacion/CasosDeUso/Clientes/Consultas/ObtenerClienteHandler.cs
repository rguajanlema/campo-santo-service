using campo_santo_service.Aplicacion.CasosDeUso.Clientes.Dtos;
using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Repositorios;

namespace campo_santo_service.Aplicacion.CasosDeUso.Clientes.Consultas
{
    public class ObtenerClienteHandler
    {
        private readonly IClienteRepository clienteRepository;

        public ObtenerClienteHandler(
            IClienteRepository clienteRepository
            )
        {
            this.clienteRepository = clienteRepository;
        }
        public async Task<IEnumerable<ObtenerClienteQuery>> Ejecutar()
        {
            var clientes = await clienteRepository.ObtenerTodos();
            return clientes.Select(Mapear);
        }
        private static ObtenerClienteQuery Mapear(Cliente cliente)
        {
            return new ObtenerClienteQuery
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Cedula = cliente.Cedula.Valor,
                Correo = cliente.Email.Valor,
                Telefono = cliente.Telefono.Valor,
            };
        }
    }
}
