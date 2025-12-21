using campo_santo_service.Aplicacion.CasosDeUso.Contratos.Comandos;
using campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace campo_santo_service.API.Controllers
{
    [ApiController]
    [Route("api/contratos")]
    public class ContratoController : ControllerBase
    {
        private readonly CrearContratoHandler crearContrato;

        public ContratoController(
            CrearContratoHandler crearContrato)
        {
            this.crearContrato = crearContrato;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(CrearContratoDto request)
        {
            var id = await crearContrato.Ejecutar(request);
            return CreatedAtAction(nameof(Crear), new { id }, null);
        }
    }
}
