using System.ComponentModel.DataAnnotations;

namespace BoletoBusApp.Api.Dtos.Configuration.Bus
{
    public record BusDisableOrEnableDto
    {
        [Required(ErrorMessage = "El Id del bus es requerido.")]
        public int BusId { get; set; }

        [Required(ErrorMessage = "El Estatus es requerido.")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "El usuario que esta haciendo el registro es requerido.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "La fecha creación es requerida.")]
        public DateTime FechaCambio { get; set; }


    }
}
