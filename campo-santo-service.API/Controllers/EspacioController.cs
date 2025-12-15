using campo_santo_service.API.Hubs;
using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Comandos;
using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Consultas;
using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace campo_santo_service.API.Controllers
{
    [ApiController]
    [Route("api/espacios")]
    public class EspacioController : ControllerBase
    {
        private readonly CrearEspacioHandler crearEspacio;
        private readonly TodosEspacioHandler todosEspacio;
        private readonly ObtenerEspacioHandler obtenerEspacio;
        private readonly IHubContext<EspaciosHub> hubContext;

        public EspacioController(
            CrearEspacioHandler crearEspacio, 
            TodosEspacioHandler todosEspacio,
            ObtenerEspacioHandler obtenerEspacio,
            IHubContext<EspaciosHub> hubContext
            )
        {
            this.crearEspacio = crearEspacio;
            this.todosEspacio = todosEspacio;
            this.obtenerEspacio = obtenerEspacio;
            this.hubContext = hubContext;
        }

        [HttpPost("{id}/ocupar")]
        public async Task<IActionResult> Ocupar(Guid id)
        {
            return Ok();
        }
        [HttpPost("crear")]
        public async Task<IActionResult> Crear(CrearEspacioDto request)
        {
            var id = await crearEspacio.Ejecutar(request);
            return CreatedAtAction(nameof(Crear), new { id }, null);
        }
        [HttpGet("todo")]
        public async Task<IActionResult> Todo()
        {
            var resultado = await todosEspacio.Ejecutar();
            return Ok(resultado);
        }
        [HttpPost("{id}/obtener")]
        public async Task<IActionResult> Obtener(Guid id)
        {
            var resultado = await obtenerEspacio.Ejecutar(id);
            return Ok(resultado);
        }
    }
}
