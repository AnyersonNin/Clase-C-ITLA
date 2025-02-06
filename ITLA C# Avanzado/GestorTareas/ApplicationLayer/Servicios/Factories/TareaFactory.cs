using DomainLayer.Models;

namespace ApplicationLayer.Factories
{
    public class TareaFactory
    {
       public static Tarea CreaAltaPriodiadTarea(string descripcion)
       {

            return new Tarea
            {     
                Descripcion = descripcion,
                Estatus = "Pendiente",
                FechaVencimiento = DateTime.Now.AddDays(1),
                DatosAdicionales = "Alta prioridad"
            };
        }
        public static Tarea CrearTareaMediaPrioridad(string descripcion)
        {
            return new Tarea
            {
                Descripcion = descripcion,
                Estatus = "Pendiente",
                FechaVencimiento = DateTime.UtcNow.AddDays(5),
                DatosAdicionales = "Media prioridad"
            };
        }

        public static Tarea CrearTareaBajaPrioridad(string descripcion)
        {
            return new Tarea
            {
                Descripcion = descripcion,
                Estatus = "Pendiente",
                FechaVencimiento = DateTime.UtcNow.AddDays(10),
                DatosAdicionales = "Baja prioridad"
            };
        }

    }
}
