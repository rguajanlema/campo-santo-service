using campo_santo_service.Aplicacion.CasosDeUso.Clientes.Dtos;
using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.ObjetosDeValor;
using campo_santo_service.Dominio.Repositorios;

namespace campo_santo_service.Aplicacion.CasosDeUso.Clientes.Consultas
{
    public class BuscarClienteHandler
    {
        private readonly IClienteRepository clienteRepository;

        public BuscarClienteHandler(
            IClienteRepository clienteRepository
            )
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteResponse>> Ejecutar(BuscarClienteQuery query)
        {
            return query.Tipo switch
            {
                TipoBusqueda.Nombre => await BuscarPorNombre(query.Valor),
                TipoBusqueda.Cedula => await BuscarPorCedula(query.Valor),
                TipoBusqueda.Contrato => await BuscarPorContrato(query.Valor),
                _ => throw new InvalidOperationException("Tipo de búsqueda no soportado")
            };
        }
        private async Task<IEnumerable<ClienteResponse>> BuscarPorNombre(string nombre)
        {
            var clientes = await clienteRepository.ObtenerPorNombre(nombre);

            return clientes.Select(Mapear);
        }
        private async Task<IEnumerable<ClienteResponse>> BuscarPorCedula(string cedula)
        {
            var cliente = await clienteRepository.ObtenerPorCedula(new Cedula(cedula));

            if (cliente is null)
                return Enumerable.Empty<ClienteResponse>();

            return new[] { Mapear(cliente) };
        }
        private async Task<IEnumerable<ClienteResponse>> BuscarPorContrato(string contrato)
        {
            var cliente = await clienteRepository.ObtenerPorContrato(contrato);

            if (cliente is null)
                return Enumerable.Empty<ClienteResponse>();

            return new[] { Mapear(cliente) };
        }
        private static ClienteResponse Mapear(Cliente cliente)
        {
            return new ClienteResponse {
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
