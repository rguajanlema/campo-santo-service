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
        private readonly IContratoRepository contratoRepository;

        public CrearContratoHandler(IUnidadDeTrabajo uow, 
            IClienteRepository clienteRepository,
            IContratoRepository contratoRepository
            )
        {
            this.uow = uow;
            this.clienteRepository = clienteRepository;
            this.contratoRepository = contratoRepository;
        }

        public async Task<Guid> Ejecutar(CrearContratoCommand dto)
        {
            var cliente = await clienteRepository
                .ObtenerPorCedula(new Cedula(dto.Familiar.Cedula));

            if(cliente is null)
            {
                cliente = Cliente.Crear(
                dto.Familiar.Nombre,
                dto.Familiar.Apellido,
                dto.Familiar.Direccion,
                new Cedula(dto.Familiar.Cedula),
                new Email(dto.Familiar.Correo),
                new Telefono(dto.Familiar.Telefono)
                );

                await clienteRepository.Agregar(cliente);
            }
            

            var contrato = Contrato.Crear(
                new CodigoContrato(dto.Codigo),
                cliente.Id,
                Enum.Parse<EnumContrato>(dto.TipoContrato),
                dto.Monto,
                new FechaContrato(dto.FechaInicio),
                dto.EspacioId,
                dto.Observaciones,
                new FechaContrato(dto.PagoInicial.FechaPago),
                dto.PagoInicial.Monto,
                dto.PagoInicial.Observaciones
                );

            
            await contratoRepository.Agregar(contrato);
            await uow.CommitAsync();

            return contrato.Id;
        }
    }
}
