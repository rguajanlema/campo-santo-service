using campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos;
using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.ObjetosDeValor;
using campo_santo_service.Dominio.Repositorios;


namespace campo_santo_service.Aplicacion.CasosDeUso.Contratos.Comandos
{
    public class CrearContratoHandler
    {
        private readonly IUnidadDeTrabajo uow;
        private readonly IClienteRepository clienteRepository;
        private readonly IPagoRepository pagoRepository;
        private readonly IContratoRepository contratoRepository;

        public CrearContratoHandler(IUnidadDeTrabajo uow, 
            IClienteRepository clienteRepository,
            IPagoRepository pagoRepository,
            IContratoRepository contratoRepository
            )
        {
            this.uow = uow;
            this.clienteRepository = clienteRepository;
            this.pagoRepository = pagoRepository;
            this.contratoRepository = contratoRepository;
        }

        public async Task<Guid> Ejecutar(CrearContratoDto dto)
        {
            var cliente = Cliente.Crear(
                dto.FamiliarDto.Nombre,
                dto.FamiliarDto.Apellido,
                dto.FamiliarDto.Direccion,
                new Cedula(dto.FamiliarDto.Cedula),
                new Email(dto.FamiliarDto.Correo),
                new Telefono(dto.FamiliarDto.Telefono)
                );

            var contrato = Contrato.Crear(
                new CodigoContrato(dto.Codigo),
                cliente.Id,
                Enum.Parse<EnumContrato>(dto.TipoContrato),
                dto.Monto,
                new FechaContrato(dto.FechaInicio),
                dto.EspacioId,
                EstadoContrato.Activo,
                dto.Observaciones
                );

            contrato.RegistrarPagoInicial(
                new FechaContrato(dto.FechaInicio),
                dto.Monto,
                dto.Observaciones
                );

            await clienteRepository.Agregar(cliente);
            await contratoRepository.Agregar(contrato);

            await uow.CommitAsync();

            return contrato.Id;
        }
    }
}
