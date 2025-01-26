using ApplicationLayer.Servicios.ServicioTarea;
using DomainLayer.Models;
using InfrastructureLayer;
using InfrastructureLayer.Repositorio.Comun;
using InfrastructureLayer.Repositorio.TareasRespositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<GestorTareasContexto>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GTareaConexion"));

});

builder.Services.AddScoped<IProcesoComun<Tarea>,TareasRepositorio>();
builder.Services.AddScoped<TareaServicio>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<GestorTareasContexto>();
//     context.Database.Migrate();

//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
