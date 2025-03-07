using DomainLayer.Models;
using InfrastructureLayer.Repositorio.Comun;
using Microsoft.EntityFrameworkCore;
using System.Reactive.Linq;
using System.Collections.Concurrent;
using DomainLayer.DTO;
using InfrastructureLayer.HUBS;
using Microsoft.AspNetCore.SignalR;



namespace InfrastructureLayer.Repositorio.TareasRespositorio
{
    public class TareasRepositorio : IProcesoComun<Tarea>
    {
        private readonly GestorTareasContexto _Contexto;
        private readonly IHubContext<TareasHub> _hubContext;
        private static readonly ConcurrentDictionary<string,object> 
        _cache = new ConcurrentDictionary<string, object>();

        public delegate bool ValidarTarea(Tarea tarea);

        private readonly ValidarTarea _validarTarea = tarea =>
        !string.IsNullOrWhiteSpace(tarea.Descripcion) &&
        tarea.FechaVencimiento > DateTime.Now;
      
        private readonly Func<Tarea, int> _calcularDiasRestantes = tarea =>
        (tarea.FechaVencimiento - DateTime.Now).Days;

        private readonly Queue<Tarea> _filaTarea = new Queue<Tarea>();

        private static readonly ConcurrentDictionary<(int Total, int Completadas), double>
        _promedioCompletas = new ConcurrentDictionary<(int, int), double>();
        public TareasRepositorio(GestorTareasContexto contexto, IHubContext<TareasHub> hubContext)
        {
            _Contexto = contexto;
            _hubContext = hubContext;
        }

        private void LimpiarCache()
        {
            _cache.Clear();
        }
        public async Task<double> GetPromedioCompletasAsync()
        {
            var todasLasTareas = await GetAllAsync();
            var tareasCompletas = await GetCompletasAsync();

            int totalTareas = todasLasTareas.Count();
            int tareasCompletadas = tareasCompletas.Count();

            if (totalTareas == 0) return 0.0;

            var cacheKey = (totalTareas, tareasCompletadas);

            if (_promedioCompletas.TryGetValue(cacheKey, out var cachedResult))
            {
                Console.WriteLine("cache");
                return cachedResult;
            }
            Console.WriteLine("DB");
            double completionRate = (double)tareasCompletadas / totalTareas * 100;
            _promedioCompletas[cacheKey] = completionRate;

            return completionRate;
        }
        public async Task<IEnumerable<Tarea>> GetCompletasAsync()
        {
            string cacheKey = "tareas_completas";
            if (_cache.TryGetValue(cacheKey, out var cachedData))
            {
                Console.WriteLine("cache");
                return (IEnumerable<Tarea>)cachedData;
            }
            Console.WriteLine("DB");
            var tareasCompletas = await _Contexto.Tareas
                .Where(tarea => tarea.Estatus == "Completas").ToListAsync();
            tareasCompletas.ForEach(x => x.TiempoRestante = _calcularDiasRestantes(x));

            _cache[cacheKey] = tareasCompletas;
            return tareasCompletas;


        }
        public async Task<IEnumerable<Tarea>> GetPendientesAsync()
        {
            string cacheKey = "tareas_pendientes";
            if (_cache.TryGetValue(cacheKey, out var cachedData))
            {
                Console.WriteLine("cache");
                return (IEnumerable<Tarea>)cachedData;
            }
            Console.WriteLine("DB");
            var tareasPendientes = await _Contexto.Tareas
                .Where(tarea => tarea.Estatus == "Pendiente").ToListAsync();
                 tareasPendientes.ForEach(x => x.TiempoRestante = _calcularDiasRestantes(x));

            _cache[cacheKey] = tareasPendientes;
            return tareasPendientes;
        }
        public async Task<IEnumerable<Tarea>> GetAllAsync()
        {
            string cacheKey = "todas_las_tareas";
            if (_cache.TryGetValue(cacheKey, out var cachedData))
            {
                Console.WriteLine("cache");
                return (IEnumerable<Tarea>)cachedData;
            }
            Console.WriteLine("DB");
            var tareas = await _Contexto.Tareas.ToListAsync();

            var tareasConTiempo = tareas.Select(x => new Tarea
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                FechaVencimiento = x.FechaVencimiento,
                Estatus = x.Estatus,
                TiempoRestante = _calcularDiasRestantes(x)
            }).ToList();

            _cache[cacheKey] = tareasConTiempo;
            return tareasConTiempo;
        }

        public async Task<Tarea> GetIdAsync(int id)
        {
            string cacheKey = $"tarea_{id}";
            if (_cache.TryGetValue(cacheKey, out var cachedData))
            {
                Console.WriteLine("cache");
                return (Tarea)cachedData;
            }
            Console.WriteLine("DB");
            var tarea = await _Contexto.Tareas.FirstOrDefaultAsync(x => x.Id == id);

            if (tarea != null)
                tarea.TiempoRestante = _calcularDiasRestantes(tarea);

            _cache[cacheKey] = tarea;
            return tarea;
        }
        public async Task<(bool IsSucces, string Message)> AddAsync(Tarea entry)
        {
            try
            {
                if (!_validarTarea(entry))
                    return (false, "Datos incompletos o fecha no valida.");

                var existe = _Contexto.Tareas.Any(x => x.Descripcion == entry.Descripcion);

                if (existe)
                {

                    return (false, "La tarea ya existe una tarea con esa descripcion ");
                }

                Console.WriteLine($"Tarea agregada a la cola: {entry.Descripcion}");

                _filaTarea.Enqueue(entry);
                Console.WriteLine($"Tarea agregada a la cola: {entry.Descripcion}");
             

                while (_filaTarea.Count > 0)
                {

                    var tareaEnProceso = _filaTarea.Dequeue();
                    await _Contexto.Tareas.AddAsync(tareaEnProceso);
                    Console.WriteLine($"Procesando tarea: {tareaEnProceso.Descripcion}");

                }

                await _Contexto.SaveChangesAsync();
                LimpiarCache();
                 
                await _hubContext.Clients.All.SendAsync("RecibirNuevaTarea", entry);

                return (true, "La tarea se guardo Correctamente...");
            }
            catch (Exception)
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
                LimpiarCache();

                await _hubContext.Clients.All.SendAsync("RecibirActualizacionTarea", entry);

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
                    LimpiarCache();
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