using ApplicationLayer.Servicios.ServicioTarea;
using DomainLayer.DTO;
using DomainLayer.Models;
using DomainLayer.Sesion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestorTareasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TareaController : ControllerBase
    {
        private readonly TareaServicio _Servicio;

        public TareaController(TareaServicio servicio)
        {
            _Servicio = servicio;
        }

        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<Respuesta<Tarea>>> GetTareaAllAsync()
        => await _Servicio.GetTareaAllAsync();

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<Respuesta<Tarea>>> GetTareaByIdAllAsync(int id)
        => await _Servicio.GetTareaByIdAllAsync(id);

        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<Respuesta<string>>> AddTareaAllAsync(Tarea tarea)
        => await _Servicio.CrearTareaConPrioridad(tarea.Descripcion, tarea.DatosAdicionales);
    
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Respuesta<string>>> UpdateTareaAllAsync(Tarea tarea)
        => await _Servicio.UpdateTareaAllAsync(tarea);

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Respuesta<string>>> DeleteTareaAllAsync(int id)
        => await _Servicio.DeleteTareaAllAsync(id);

        [HttpGet("pendientes")]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<Respuesta<Tarea>>> GetPendientesAsync()
        => await _Servicio.GetPendientesAsync();

        [HttpGet("completas")]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<Respuesta<Tarea>>> GetCompletasAsync()
        => await _Servicio.GetCompletasAsync();

        [HttpGet("PromedioCompletas")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Respuesta<object>>> GetPromedioCompletasAsync()
         => await _Servicio.GetPromedioCompletasAsync();

    }
}
