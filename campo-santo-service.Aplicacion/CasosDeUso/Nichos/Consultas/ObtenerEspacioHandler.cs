using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Dtos;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.Repositorios;


namespace campo_santo_service.Aplicacion.CasosDeUso.Nichos.Consultas
{
    public class ObtenerEspacioHandler
    {
        private readonly IEspacioRepository repository;

        public ObtenerEspacioHandler(IEspacioRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ObtenerEspacioDto> Ejecutar(Guid id)
        {
            var resultado = await repository.ObtenerPorId(id);
            if (resultado == null)
            {
                throw new ExcepcionDeReglaDeNegocio($"Error en obtener el espacio: {id}");
            }

            return new ObtenerEspacioDto
            {
                Id = resultado.Id,
                Codigo = resultado.Codigo.Valor,
                Tipo = resultado.Tipo.ToString(),
                Piso = resultado.Piso.ToString(),
                Estado = resultado.Estado.ToString(),
                Ubicacion = resultado.Ubicacion
            };
        }
    }
}
