using campo_santo_service.Aplicacion.CasosDeUso.Servicios.Comandos;
using campo_santo_service.Aplicacion.CasosDeUso.Servicios.Consultas;
using campo_santo_service.Aplicacion.CasosDeUso.Servicios.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace campo_santo_service.API.Controllers
{
    [ApiController]
    [Route("api/servicios")]
    public class ServicioController : ControllerBase
    {
        private readonly CrearServicioHandler crearServicio;
        private readonly TodosServicioHandler todosServicio;

        public ServicioController(CrearServicioHandler crearServicio, TodosServicioHandler todosServicio)
        {
            this.crearServicio = crearServicio;
            this.todosServicio = todosServicio;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(CrearServicioDto request)
        {
            var id = await crearServicio.Ejecutar(request);
            return CreatedAtAction(nameof(Crear), new { id }, null);
        }

        [HttpGet("todo")]
        public async Task<IActionResult> Todo()
        {
            var resultado = await todosServicio.Ejecutar();
            return Ok(resultado);
        }
    }
}
