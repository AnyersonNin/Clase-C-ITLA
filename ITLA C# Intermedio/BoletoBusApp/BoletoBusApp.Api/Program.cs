
using BoletoBusApp.Data.Context;
using BoletoBusApp.Data.Interfaces;
using BoletoBusApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BoletoBusApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<BoletoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BoletoConnString")));

            builder.Services.AddTransient<IAsientosRepository, AsientoRepository>();
            builder.Services.AddTransient<IBusRepository, BusRepository>();
            builder.Services.AddTransient<IConductorBusRepository, ConductorBusRepository>();
            builder.Services.AddTransient<IConductorRepository, ConductorRepository>();
            builder.Services.AddTransient<IReservaDetalleRepository, ReservaDetalleRepository>();
            builder.Services.AddTransient<IReservaRepository, ReservaRepository>();
            builder.Services.AddTransient<IRutaRepository, RutaRepository>();
            builder.Services.AddTransient<IStatusRepository, StatusRepository>();
            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddTransient<IViajeRepository, ViajeRepository>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
