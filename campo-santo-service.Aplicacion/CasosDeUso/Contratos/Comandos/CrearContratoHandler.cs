using campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos;
using campo_santo_service.Aplicacion.Common;
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
        private readonly IEspacioRepository espacioRepository;
        

        public CrearContratoHandler(IUnidadDeTrabajo uow, 
            IClienteRepository clienteRepository,
            IContratoRepository contratoRepository,
            IEspacioRepository espacioRepository
            )
        {
            this.uow = uow;
            this.clienteRepository = clienteRepository;
            this.contratoRepository = contratoRepository;
            this.espacioRepository = espacioRepository;
        }

        public async Task<Guid> Ejecutar(CrearContratoCommand dto)
        {
            var cliente = await clienteRepository
                .ObtenerPorCedula(new Cedula(dto.Familiar.Cedula));

            if (cliente is null)
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

            var espacio = await espacioRepository.ObtenerPorId(dto.EspacioId);

            if(espacio is null)
                throw new InvalidOperationException("El espacio no existe");

            espacio.Ocupar();

            await espacioRepository.Actualizar(espacio);

            var contrato = Contrato.Crear(
                new CodigoContrato(dto.Codigo),
                cliente.Id,
                Enum.Parse<EnumContrato>(dto.TipoContrato),
                dto.Monto,
                new FechaContrato(DateTimeNormalizer.ToUtc(dto.FechaInicio)),
                dto.EspacioId,
                dto.Observaciones,
                new FechaContrato(DateTimeNormalizer.ToUtc(dto.PagoInicial.FechaPago)),
                dto.PagoInicial.Monto,
                dto.PagoInicial.Observaciones
                );

            
            await contratoRepository.Agregar(contrato);
            await uow.CommitAsync();

            return contrato.Id;
        }
    }
}
