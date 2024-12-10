using System.ComponentModel.DataAnnotations;

namespace BoletoBusApp.Api.Dtos.Configuration.Bus
{
    public record BusSaveOrUpdateDto
    {
        [Required(ErrorMessage = "El Id del bus es requerido.")]
        public int BusId { get; set; }
        [Required(ErrorMessage = "El número de placa es requerido.")]
        [StringLength(50, ErrorMessage = "La longitud de la placa es inválida.")]
        public string? NumeroPlaca { get; set; }
        [Required(ErrorMessage = "El nombre del bus es requerido")]
        [StringLength(50, ErrorMessage = "La longitud del nombre es inválida.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La capacidad del 1er. piso es requerida.")]
        public int CapacidadPiso1 { get; set; }

        [Required(ErrorMessage = "La capacidad del 2do. piso es requerida.")]
        public int CapacidadPiso2 { get; set; }

        [Required(ErrorMessage = "La disponibilidad del bus es requerida.")]
        public bool Disponible { get; set; }

        [Required(ErrorMessage = "El usuario que esta haciendo el registro es requerido.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "La fecha creación es requerida.")]
        public DateTime FechaCambio { get; set; }

    }
}

