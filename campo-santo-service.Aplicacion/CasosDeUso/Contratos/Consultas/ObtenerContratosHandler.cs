using campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.Repositorios;

namespace campo_santo_service.Aplicacion.CasosDeUso.Contratos.Consultas
{
    public class ObtenerContratosHandler
    {
        private readonly IContratoRepository contratoRepository;
        private readonly IClienteRepository clienteRepository;

        public ObtenerContratosHandler(
            IContratoRepository contratoRepository,
            IClienteRepository clienteRepository
            )
        {
            this.contratoRepository = contratoRepository;
            this.clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ObtenerContrato>> Ejecutar()
        {
            var resultContratos = await contratoRepository.ObtenerTodo();
            var lista = new List<ObtenerContrato>();

            foreach(var contrato in resultContratos)
            {
                var resultCliente = await clienteRepository.ObtenerPorId(contrato.ClienteId) ??
                 throw new ExcepcionDeReglaDeNegocio("Cliente no encontrado");

                lista.Add(new ObtenerContrato(
                    id:contrato.Id,
                    nombre:resultCliente.Nombre,
                    apellido:resultCliente.Apellido,
                    codigo:contrato.Codigo.Valor,
                    cedula:resultCliente.Cedula.Valor
                ));
            }
            
            return lista;
        }
    }
}
