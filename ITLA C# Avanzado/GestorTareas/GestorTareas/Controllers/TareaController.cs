using ApplicationLayer.Servicios.ServicioTarea;
using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorTareasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly TareaServicio _Servicio;

        public TareaController(TareaServicio servicio)
        {
            _Servicio = servicio;
        }


         [HttpGet]
        public async Task<ActionResult<Respuesta<Tarea>>> GetTareaAllAsync()
         => await _Servicio.GetTareaAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Respuesta<Tarea>>> GetTareaByIdAllAsync(int id)
          => await _Servicio.GetTareaByIdAllAsync(id);

        [HttpPost]
        public async Task<ActionResult<Respuesta<string>>> AddTareaAllAsync(Tarea tarea)
        => await _Servicio.CrearTareaConPrioridad(tarea.Descripcion, tarea.DatosAdicionales);
       

        [HttpPut]
        public async Task<ActionResult<Respuesta<string>>> UpdateTareaAllAsync(Tarea tarea)
         => await _Servicio.UpdateTareaAllAsync(tarea);

        [HttpDelete("{id}")]
        public async Task<ActionResult<Respuesta<string>>> DeleteTareaAllAsync(int id)
        => await _Servicio.DeleteTareaAllAsync(id);

        [HttpGet("pendientes")]
        public async Task<ActionResult<Respuesta<Tarea>>> GetPendientesAsync()
        => await _Servicio.GetPendientesAsync();


    }
}
