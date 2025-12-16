using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Dtos;
using campo_santo_service.Aplicacion.CasosDeUso.Servicios.Comandos;
using campo_santo_service.Aplicacion.CasosDeUso.Servicios.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace campo_santo_service.API.Controllers
{
    [ApiController]
    [Route("api/servicios")]
    public class ServicioController : ControllerBase
    {
        private readonly CrearServicioHandler crearServicio;

        public ServicioController(CrearServicioHandler crearServicio)
        {
            this.crearServicio = crearServicio;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(CrearServicioDto request)
        {
            var id = await crearServicio.Ejecutar(request);
            return CreatedAtAction(nameof(Crear), new { id }, null);
        }
    }
}
