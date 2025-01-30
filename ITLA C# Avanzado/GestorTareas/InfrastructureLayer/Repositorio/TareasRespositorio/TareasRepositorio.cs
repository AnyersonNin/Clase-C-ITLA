using DomainLayer.Models;
using InfrastructureLayer.Repositorio.Comun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositorio.TareasRespositorio
{
    public class TareasRepositorio : IProcesoComun<Tarea>
    {
        private readonly GestorTareasContexto _Contexto;
        public TareasRepositorio(GestorTareasContexto contexto)
        {
            _Contexto = contexto;
        }

        public async Task<IEnumerable<Tarea>> GetAllAsync()
            => await _Contexto.Tareas.ToListAsync();

        public async Task<Tarea> GetIdAsync(int id)
           => await _Contexto.Tareas.FirstOrDefaultAsync(x=>x.Id == id);

        public async Task<(bool IsSucces, string Message)> AddAsync(Tarea entry)
        {
            try
            {
                var existe =  _Contexto.Tareas.Any(x => x.Descripcion == entry.Descripcion);
                if (existe) {

                    return (false, "La tarea ya existe una tarea con esa descripcion ");
                }
                await _Contexto.Tareas.AddAsync(entry);
                await _Contexto.SaveChangesAsync();
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
                var existe = _Contexto.Tareas.Any(x => x.Descripcion == entry.Descripcion);
                if (existe)
                {

                    return (false, "La tarea ya existe una tarea con esa descripcion ");
                }
                _Contexto.Tareas.Update(entry);
                await _Contexto.SaveChangesAsync();
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
