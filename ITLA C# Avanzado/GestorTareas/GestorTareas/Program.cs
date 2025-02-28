using ApplicationLayer.Servicios.ServicioTarea;
using DomainLayer.Models;
using InfrastructureLayer;
using InfrastructureLayer.Repositorio.Comun;
using InfrastructureLayer.Repositorio.TareasRespositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApplicationLayer.Servicios.ServicioUsuario;
using InfrastructureLayer.Repositorio.UsuarioRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<GestorTareasContexto>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GTareaConexion"));

});

builder.Services.AddScoped<IProcesoComun<Tarea>,TareasRepositorio>();
builder.Services.AddScoped<IProcesoComun<Usuario>,UsuarioRepositorio>();
builder.Services.AddScoped<TareaServicio>();
builder.Services.AddScoped<UsuarioServicio>();
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddControllers();

var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<GestorTareasContexto>();
//    context.Database.Migrate();

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
