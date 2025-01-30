﻿using DomainLayer.DTO;
using DomainLayer.Models;
using InfrastructureLayer.Repositorio.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Servicios.ServicioTarea
{
    public class TareaServicio
    {
        private readonly IProcesoComun<Tarea> _procesoComun;
        public TareaServicio(IProcesoComun<Tarea> procesoComun)
        {
         _procesoComun = procesoComun;
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
