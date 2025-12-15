using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Dtos;
using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Dominio.Repositorios;


namespace campo_santo_service.Aplicacion.CasosDeUso.Nichos.Consultas
{
    public class TodosEspacioHandler
    {
        private readonly IEspacioRepository repository;
        
        public TodosEspacioHandler(IEspacioRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<TodoEspacioDto>> Ejecutar()
        {
            var resultados = await repository.ObtenerTodo();
            var lista = resultados.Select(resultado => new TodoEspacioDto
            {
                Id = resultado.Id,
                Codigo = resultado.Codigo.Valor,
                Tipo = resultado.Tipo.ToString(),
                Piso = resultado.Piso.ToString(),
                Estado = resultado.Estado.ToString(),
                Ubicacion = resultado.Ubicacion
            });

            return lista;
        }
    }
}
