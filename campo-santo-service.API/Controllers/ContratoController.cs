using campo_santo_service.Aplicacion.CasosDeUso.Contratos.Comandos;
using campo_santo_service.Aplicacion.CasosDeUso.Contratos.Consultas;
using campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace campo_santo_service.API.Controllers
{
    [ApiController]
    [Route("api/contratos")]
    public class ContratoController : ControllerBase
    {
        private readonly CrearContratoHandler crearContrato;
        private readonly ObtenerContratosHandler obtenerContratos;

        public ContratoController(
            CrearContratoHandler crearContrato,
            ObtenerContratosHandler obtenerContratos
            )
        {
            this.crearContrato = crearContrato;
            this.obtenerContratos = obtenerContratos;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crear(CrearContratoCommand request)
        {
            var id = await crearContrato.Ejecutar(request);
            return CreatedAtAction(nameof(Crear), new { id }, null);
        }
        [HttpGet("todo")]
        public async Task<IActionResult> Todo()
        {
            var resultado = await obtenerContratos.Ejecutar();
            return Ok(resultado);
        }
    }
}
