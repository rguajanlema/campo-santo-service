using campo_santo_service.API.Hubs;
using campo_santo_service.Aplicacion.CasosDeUso.Clientes.Consultas;
using campo_santo_service.Aplicacion.CasosDeUso.Contratos.Comandos;
using campo_santo_service.Aplicacion.CasosDeUso.Contratos.Consultas;
using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Comandos;
using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Consultas;
using campo_santo_service.Aplicacion.CasosDeUso.Servicios.Comandos;
using campo_santo_service.Aplicacion.CasosDeUso.Servicios.Consultas;
using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Dominio.Repositorios;
using campo_santo_service.Infraestructura.Datos.Contexto;
using campo_santo_service.Infraestructura.Datos.Repositorios;
using campo_santo_service.Infraestructura.Datos.UnitOfWork;
using campo_santo_service.Infraestructura.Middleware;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:5173","http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});




builder.Services.AddDbContext<CampoSantoDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("CementerioDb")
    )
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine, LogLevel.Information)
);




builder.Services.AddScoped<IEspacioRepository, EspacioRepositoryEF>();
builder.Services.AddScoped<IServicioRepository, ServicioRepositoryEF>();
builder.Services.AddScoped<IContratoRepository, ContratoRepositoryEF>();
builder.Services.AddScoped<IClienteRepository, ClienteRepositoryEF>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnitOfWorkEF>();

builder.Services.AddScoped<CrearEspacioHandler>();
builder.Services.AddScoped<TodosEspacioHandler>();
builder.Services.AddScoped<DisponiblesEspacioHandler>();
builder.Services.AddScoped<ObtenerEspacioHandler>();

builder.Services.AddScoped<TodosServicioHandler>();
builder.Services.AddScoped<CrearServicioHandler>();

builder.Services.AddScoped<CrearContratoHandler>();
builder.Services.AddScoped<ObtenerContratosHandler>();

builder.Services.AddScoped<BuscarClienteHandler>();
builder.Services.AddScoped<ObtenerClienteHandler>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });


var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();
app.MapHub<EspaciosHub>("/hubs/espacios");

app.Run();