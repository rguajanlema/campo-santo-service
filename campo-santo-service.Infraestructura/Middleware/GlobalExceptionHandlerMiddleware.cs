using campo_santo_service.Dominio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;


namespace campo_santo_service.Infraestructura.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ExcepcionDeReglaDeNegocio ex)
            {
                _logger.LogWarning($"{this.GetType().FullName} -> Error de negocio -> [{ex.Message}]");

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await WriteJsonAsync(context, new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Excepción inesperada en {this.GetType().FullName}");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await WriteJsonAsync(context, new { success = false, message = "Error inesperado" });
            }
        }
        private Task WriteJsonAsync(HttpContext context, object payload)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            var json = JsonSerializer.Serialize(payload, _jsonOptions);
            return context.Response.WriteAsync(json);
        }
    }

}
