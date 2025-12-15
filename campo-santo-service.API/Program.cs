using campo_santo_service.API.Hubs;
using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Comandos;
using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Consultas;
using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Dominio.Repositorios;
using campo_santo_service.Infraestructura.Datos.Contexto;
using campo_santo_service.Infraestructura.Datos.Repositorios;
using campo_santo_service.Infraestructura.Datos.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:5173") // tu frontend
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); // si usas cookies o auth
    });
});




builder.Services.AddDbContext<CampoSantoDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("CementerioDb")
    )
);

builder.Services.AddScoped<IEspacioRepository, EspacioRepositoryEF>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnitOfWorkEF>();

builder.Services.AddScoped<CrearEspacioHandler>();
builder.Services.AddScoped<TodosEspacioHandler>();
builder.Services.AddScoped<ObtenerEspacioHandler>();


var app = builder.Build();



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