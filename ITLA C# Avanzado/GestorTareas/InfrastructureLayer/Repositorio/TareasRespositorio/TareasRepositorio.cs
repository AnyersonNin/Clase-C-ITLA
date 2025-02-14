using DomainLayer.Models;
using InfrastructureLayer.Repositorio.Comun;
using Microsoft.EntityFrameworkCore;
using System.Reactive.Linq;
using System.Collections.Concurrent;



namespace InfrastructureLayer.Repositorio.TareasRespositorio
{
    public class TareasRepositorio : IProcesoComun<Tarea>
    {
        private readonly GestorTareasContexto _Contexto;

        public delegate bool ValidarTarea(Tarea tarea);

        private readonly ValidarTarea _validarTarea = tarea =>
        !string.IsNullOrWhiteSpace(tarea.Descripcion) && tarea.FechaVencimiento > DateTime.Now;

        private readonly Action<Tarea> _notificar = tarea =>
        Console.WriteLine($"Tarea creada: {tarea.Descripcion}, Vencimiento: {tarea.FechaVencimiento}");

        private readonly Func<Tarea, int> _calcularDiasRestantes = tarea =>
        (tarea.FechaVencimiento - DateTime.Now).Days;

        private readonly Queue<Tarea> _filaTarea = new Queue<Tarea>();

        public TareasRepositorio(GestorTareasContexto contexto)
        {
            _Contexto = contexto;
        }



        public async Task<IEnumerable<Tarea>> GetPendientesAsync()
        {
            var tareasPendientes = await _Contexto.Tareas.Where(tarea => tarea.Estatus == "Pendiente").ToListAsync();

            tareasPendientes.ForEach(x => x.TiempoRestante = _calcularDiasRestantes(x));
        
            return tareasPendientes;           
        }
        public async Task<IEnumerable<Tarea>> GetAllAsync()
        {
            var tareas = await _Contexto.Tareas.ToListAsync();
            return tareas.Select(x => new Tarea
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                FechaVencimiento = x.FechaVencimiento,
                Estatus = x.Estatus,
                TiempoRestante = _calcularDiasRestantes(x)

            }).ToList();
        }

        public async Task<Tarea> GetIdAsync(int id)
        { 
           var tarea = await _Contexto.Tareas.FirstOrDefaultAsync(x => x.Id == id);
            
            if (tarea != null)
            {
                tarea.TiempoRestante = _calcularDiasRestantes(tarea);
            }
            return tarea!;
        }
        public async Task<(bool IsSucces, string Message)> AddAsync(Tarea entry)
        {
            try
            {
                if (!_validarTarea(entry))
                    return (false, "Datos incompletos o fecha no valida.");

                var existe =  _Contexto.Tareas.Any(x => x.Descripcion == entry.Descripcion);

                if (existe) {

                    return (false, "La tarea ya existe una tarea con esa descripcion ");
                }

                Console.WriteLine($"Tarea agregada a la cola: {entry.Descripcion}");

                _filaTarea.Enqueue(entry);
                Console.WriteLine($"Tarea agregada a la cola: {entry.Descripcion}");
                _notificar(entry);

                while (_filaTarea.Count > 0)
                {

                    var tareaEnProceso = _filaTarea.Dequeue();
                    await _Contexto.Tareas.AddAsync(tareaEnProceso);
                    Console.WriteLine($"Procesando tarea: {tareaEnProceso.Descripcion}");
                   
                }

                await _Contexto.SaveChangesAsync();
                _notificar(new Tarea { Descripcion = "Proceso de guardado completado" });

                return (true,"La tarea se guardo Correctamente...");
            }
            catch(Exception) 
            {
                return (false, "La tarea no se pudo guardar...");
            }
        }

        public async Task<(bool IsSucces, string Message)> UpdateAsync(Tarea entry)
        {
            try
            {
                if (!_validarTarea(entry))
                {
                    return (false, "Datos incompletos o fecha no valida.");
                } 

                var existe = _Contexto.Tareas.Any(x => x.Descripcion == entry.Descripcion);
                if (existe)
                {

                    return (false, "La tarea ya existe una tarea con esa descripcion ");
                }
                _Contexto.Tareas.Update(entry);
                await _Contexto.SaveChangesAsync();

                _notificar(entry);


                return (true, "La tarea se actualizo Correctamente...");
            }
            catch (Exception)
            {
                return (false, "La tarea no se pudo Actualizar...");
            }
        }

        public async Task<(bool IsSucces, string Message)> DeleteAsync(int id)
        {
            try
            {
                var tarea = await _Contexto.Tareas.FindAsync(id);
                if (tarea != null)
                {
                    _Contexto.Tareas.Remove(tarea);
                    await _Contexto.SaveChangesAsync();
                    return (true, "La tarea se elimino Correctamente...");
                }
                else
                {
                    return (false, "No se encontro la tarea...");
                }
                
            }
            catch (Exception)
            {
                return (false, "La tarea no se pudo eliminar...");
            }
        }


    }
}
