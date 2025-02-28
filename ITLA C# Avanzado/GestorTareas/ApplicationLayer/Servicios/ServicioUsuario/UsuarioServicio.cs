using DomainLayer.DTO;
using DomainLayer.Models;
using InfrastructureLayer.Repositorio.Comun;

namespace ApplicationLayer.Servicios.ServicioUsuario
{
    public class UsuarioServicio
    {
        private readonly IProcesoComun<Usuario> _procesoComun;

        public UsuarioServicio(IProcesoComun<Usuario> procesoComun)
        {
            _procesoComun = procesoComun;
        }

        public async Task<Respuesta<Usuario>> GetUsuarioAllAsync()
        {
            var respuesta = new Respuesta<Usuario>();

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
        public async Task<Respuesta<string>> AddUsuarioAllAsync(Usuario usuario)
        {
            var respuesta = new Respuesta<string>();

            try
            {
                var resultado = await _procesoComun.AddAsync(usuario);
                respuesta.Message = resultado.Message;
                respuesta.Succesful = resultado.IsSucces;

            }
            catch (Exception ex)
            {
                respuesta.Errors.Add(ex.Message);
            }
            return respuesta;

        }

        public async Task<Respuesta<string>> UpdateTareaAllAsync(Usuario usuario)
        {
            var respuesta = new Respuesta<string>();

            try
            {
                var resultado = await _procesoComun.UpdateAsync(usuario);
                respuesta.Message = resultado.Message;
                respuesta.Succesful = resultado.IsSucces;

            }
            catch (Exception ex)
            {
                respuesta.Errors.Add(ex.Message);
            }
            return respuesta;

        }

        public async Task<Respuesta<string>> DeleteUsuarioAllAsync(int id)
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
