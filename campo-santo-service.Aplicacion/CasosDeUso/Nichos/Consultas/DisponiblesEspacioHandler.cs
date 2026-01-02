using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Dtos;
using campo_santo_service.Dominio.Repositorios;

namespace campo_santo_service.Aplicacion.CasosDeUso.Nichos.Consultas
{
    public class DisponiblesEspacioHandler
    {
        private readonly IEspacioRepository repository;

        public DisponiblesEspacioHandler(IEspacioRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<DisponibleEspacioQuery>> Ejecutar()
        {
            var resultado = await repository.ObtenerLibres();

            return resultado.Select(x=> new DisponibleEspacioQuery
            {
                Id = x.Id,
                Codigo = x.Codigo.Valor,
            });
        }
    }
}
