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
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioServicio _Servicio;

        public UsuariosController(UsuarioServicio servicio)
        {
            _Servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<Respuesta<Usuario>>> GetUsuarioAllAsync()
        => await _Servicio.GetUsuarioAllAsync();
        [HttpPost]
        public async Task<ActionResult<Respuesta<string>>> AddTareaAllAsync(Usuario usuario)
       => await _Servicio.AddUsuarioAllAsync(usuario);

        [HttpPut]
        public async Task<ActionResult<Respuesta<string>>> UpdateTareaAllAsync(Usuario usuario)
        => await _Servicio.UpdateTareaAllAsync(usuario);

        [HttpDelete("{id}")]
        public async Task<ActionResult<Respuesta<string>>> DeleteUsuarioAllAsync(int id)
        => await _Servicio.DeleteUsuarioAllAsync(id);

    }
}
