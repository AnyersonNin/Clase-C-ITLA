using ApplicationLayer.Servicios.ServicioUsuario;
using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorTareasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioServicio _Servicio;

        public UsuariosController(UsuarioServicio servicio)
        {
            _Servicio = servicio;
        }

        [HttpGet("ListaUsuario")]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<Respuesta<Usuario>>> GetUsuarioAllAsync()
        => await _Servicio.GetUsuarioAllAsync();
        [HttpPost("AgregarUsuario")]
        [Authorize(Roles = "admin,user")]
        public async Task<ActionResult<Respuesta<string>>> AddTareaAllAsync(Usuario usuario)
       => await _Servicio.AddUsuarioAllAsync(usuario);

        [HttpPut("ActualizarUsuario")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Respuesta<string>>> UpdateTareaAllAsync(Usuario usuario)
        => await _Servicio.UpdateTareaAllAsync(usuario);

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Respuesta<string>>> DeleteUsuarioAllAsync(int id)
        => await _Servicio.DeleteUsuarioAllAsync(id);

    }
}
