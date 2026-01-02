using campo_santo_service.Aplicacion.CasosDeUso.Clientes.Consultas;
using campo_santo_service.Aplicacion.CasosDeUso.Clientes.Dtos;
using campo_santo_service.Dominio.Enums;
using Microsoft.AspNetCore.Mvc;

namespace campo_santo_service.API.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly BuscarClienteHandler buscarClienteHandler;
        private readonly ObtenerClienteHandler obtenerClienteHandler;

        public ClienteController(
            BuscarClienteHandler buscarClienteHandler,
            ObtenerClienteHandler obtenerClienteHandler
            )
        {
            this.buscarClienteHandler = buscarClienteHandler;
            this.obtenerClienteHandler = obtenerClienteHandler;
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar(
            [FromQuery] TipoBusqueda tipo,
            [FromQuery] string valor
            )
        {
            var result = await buscarClienteHandler.Ejecutar(new BuscarClienteQuery(tipo, valor));
            return Ok(result);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> Todo()
        {
            var result = await obtenerClienteHandler.Ejecutar();
            return Ok(result);
        }
    }
}
