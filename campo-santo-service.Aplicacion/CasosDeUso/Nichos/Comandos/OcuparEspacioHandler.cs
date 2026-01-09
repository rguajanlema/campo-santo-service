using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Dominio.Repositorios;

namespace campo_santo_service.Aplicacion.CasosDeUso.Nichos.Comandos
{
    public class OcuparEspacioHandler
    {
        private readonly IEspacioRepository espacioRepository;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public OcuparEspacioHandler(IEspacioRepository espacioRepository, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.espacioRepository = espacioRepository;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }
        public async Task Ejecutar(OcuparEspacioCommand command)
        {
            try
            {
                var espacio = await espacioRepository.ObtenerPorId(command.EspacioId)
                    ?? throw new InvalidOperationException("El espacio no existe");

                espacio.Ocupar();

                await espacioRepository.Actualizar(espacio);

                await unidadDeTrabajo.CommitAsync();    
            }
            catch
            {
                unidadDeTrabajo.Reversar();
                throw;
            }
            
        }


    }
}
