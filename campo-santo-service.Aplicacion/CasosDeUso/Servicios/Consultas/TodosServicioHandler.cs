using campo_santo_service.Aplicacion.CasosDeUso.Servicios.Dtos;
using campo_santo_service.Dominio.Repositorios;

namespace campo_santo_service.Aplicacion.CasosDeUso.Servicios.Consultas
{
    public class TodosServicioHandler
    {
        private readonly IServicioRepository repository;

        public TodosServicioHandler(IServicioRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<TodoServicioDto>> Ejecutar()
        {
            var resultados = await repository.ObtenerTodo();
            var lista = resultados.Select(resultado => new TodoServicioDto(
                id:resultado.Id,
                nombre:resultado.Nombre,
                precio:resultado.Precio
                ));

            return lista;
        }

    }
}
