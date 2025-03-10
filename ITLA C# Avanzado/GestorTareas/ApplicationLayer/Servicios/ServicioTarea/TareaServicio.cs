﻿using ApplicationLayer.Factories;
using DomainLayer.DTO;
using DomainLayer.Models;
using InfrastructureLayer.Repositorio.Comun;
using InfrastructureLayer.Repositorio.TareasRespositorio;


namespace ApplicationLayer.Servicios.ServicioTarea
{
    public class TareaServicio
    {
        private readonly IProcesoComun<Tarea> _procesoComun;
        public TareaServicio(IProcesoComun<Tarea> procesoComun)
        {
            _procesoComun = procesoComun;
        }

        public async Task<Respuesta<string>> CrearTareaConPrioridad(string descripcion, string prioridad)
        {
            Tarea nuevaTarea;

            switch (prioridad.ToLower())
            {
                case "alta":
                    nuevaTarea = TareaFactory.CreaAltaPriodiadTarea(descripcion);
                    break;
                case "media":
                    nuevaTarea = TareaFactory.CrearTareaMediaPrioridad(descripcion);
                    break;
                case "baja":
                    nuevaTarea = TareaFactory.CrearTareaBajaPrioridad(descripcion);
                    break;
                default:
                    return new Respuesta<string> { Succesful = false, Message = "Prioridad no válida" };
            }

            var resultado = await _procesoComun.AddAsync(nuevaTarea);

            return new Respuesta<string>
            {
                Succesful = true,
                Message = "Tarea creada con éxito"
            };
        }
        public async Task<Respuesta<object>> GetPromedioCompletasAsync()
        {
            var respuesta = new Respuesta<object>();

            try
            {
                double completionRate = await _procesoComun.GetPromedioCompletasAsync();
               

                respuesta.SingleData = completionRate;
                respuesta.Message = $"Este es el promedio de tareas completadas: {completionRate:F2}%";
                respuesta.Succesful = true;
            }
            catch (Exception ex)
            {
                respuesta.Errors.Add($"Error al calcular la tasa de finalización: {ex.Message}");
            }

            return respuesta;
        }
        public async Task<Respuesta<Tarea>> GetCompletasAsync()
        {
            var respuesta = new Respuesta<Tarea>();

            try
            {
                var tareasCompletas = await _procesoComun.GetCompletasAsync();

                if (!tareasCompletas.Any())
                {
                    respuesta.Succesful = false;
                    respuesta.Message = "No hay tareas pendientes.";
                }
                else
                {
                    respuesta.DataList = tareasCompletas.ToList();
                    respuesta.Succesful = true;
                }
            }
            catch (Exception ex)
            {
                respuesta.Errors.Add($"Error en GetPendientesAsync: {ex.Message}");
            }

            return respuesta;
        }
        public async Task<Respuesta<Tarea>> GetPendientesAsync()
        {
            var respuesta = new Respuesta<Tarea>();

            try
            {
                var tareasPendientes = await _procesoComun.GetPendientesAsync();

                if (!tareasPendientes.Any())
                {
                    respuesta.Succesful = false;
                    respuesta.Message = "No hay tareas pendientes.";
                }
                else
                {
                    respuesta.DataList = tareasPendientes.ToList();
                    respuesta.Succesful = true;
                }
            }
            catch (Exception ex)
            {
                respuesta.Errors.Add($"Error en GetPendientesAsync: {ex.Message}");
            }

            return respuesta;
        }
        public async Task<Respuesta<Tarea>> GetTareaAllAsync()
        {
            var respuesta = new Respuesta<Tarea>();

            try
            {
                respuesta.DataList = await _procesoComun.GetAllAsync();
                respuesta.Succesful = true;

            }
            catch (Exception ex)
            {
                respuesta.Errors.Add(ex.Message);
            }
            return respuesta;

        }

        public async Task<Respuesta<Tarea>> GetTareaByIdAllAsync(int id)
        {
            var respuesta = new Respuesta<Tarea>();

            try
            {
                var resultado = await _procesoComun.GetIdAsync(id);
                if (resultado != null)
                {
                    respuesta.SingleData = resultado;
                    respuesta.Succesful = true;
                }
                else
                {
                    respuesta.Succesful = false;
                    respuesta.Message = "No se encontro datos";
                }

                respuesta.Succesful = true;

            }
            catch (Exception ex)
            {
                respuesta.Errors.Add(ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta<string>> AddTareaAllAsync(Tarea tarea)
        {
            var respuesta = new Respuesta<string>();

            try
            {
                var resultado = await _procesoComun.AddAsync(tarea);
                respuesta.Message = resultado.Message;
                respuesta.Succesful = resultado.IsSucces;

            }
            catch (Exception ex)
            {
                respuesta.Errors.Add(ex.Message);
            }
            return respuesta;

        }

        public async Task<Respuesta<string>> UpdateTareaAllAsync(Tarea tarea)
        {
            var respuesta = new Respuesta<string>();

            try
            {
                var resultado = await _procesoComun.UpdateAsync(tarea);
                respuesta.Message = resultado.Message;
                respuesta.Succesful = resultado.IsSucces;

            }
            catch (Exception ex)
            {
                respuesta.Errors.Add(ex.Message);
            }
            return respuesta;

        }

        public async Task<Respuesta<string>> DeleteTareaAllAsync(int id)
        {
            var respuesta = new Respuesta<string>();

            try
            {
                var resultado = await _procesoComun.DeleteAsync(id);
                respuesta.Message = resultado.Message;
                respuesta.Succesful = resultado.IsSucces;

            }
            catch (Exception ex)
            {
                respuesta.Errors.Add(ex.Message);
            }
            return respuesta;

        }


    }
}