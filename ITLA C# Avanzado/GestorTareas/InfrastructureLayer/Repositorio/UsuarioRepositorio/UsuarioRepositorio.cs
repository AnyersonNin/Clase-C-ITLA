using DomainLayer.Models;
using InfrastructureLayer.Repositorio.Comun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InfrastructureLayer.Repositorio.TareasRespositorio.TareasRepositorio;

namespace InfrastructureLayer.Repositorio.UsuarioRepositorio
{
    public class UsuarioRepositorio : IProcesoComun<Usuario>
    {
        private readonly GestorTareasContexto _Contexto;

        private void LimpiarCache()
        {
            _cache.Clear();
        }
        private static readonly ConcurrentDictionary<string, object>
        _cache = new ConcurrentDictionary<string, object>();

        public delegate bool ValidarUsuario(Usuario usuario);
        private readonly ValidarUsuario _validarUsuario = usuario =>
        !string.IsNullOrWhiteSpace(usuario.Nombre);

        private readonly Action<Usuario> _notificar = Usuario =>
        Console.WriteLine($"usuario creado: {Usuario.Nombre},Role: {Usuario.Role}");

        private readonly Queue<Usuario> _filaUsuario = new Queue<Usuario>();

        public UsuarioRepositorio(GestorTareasContexto contexto)
        {
            _Contexto = contexto;
        }
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            string cacheKey = "todos_los_usuarios";

            if (_cache.TryGetValue(cacheKey, out var cachedData))
            {
                Console.WriteLine("Cache");
                return (IEnumerable<Usuario>)cachedData;
            }

            Console.WriteLine("DB");
            var usuarios = await _Contexto.Usuarios.ToListAsync();

            var usuariosProcesados = usuarios.Select(x => new Usuario
            {
                IdUsuario = x.IdUsuario,
                Nombre = x.Nombre,
                Contrasena = x.Contrasena,
                Role = x.Role
            }).ToList();

            _cache[cacheKey] = usuariosProcesados;

            return usuariosProcesados;
        }
        public async Task<(bool IsSucces, string Message)> AddAsync(Usuario entry)
        {
            try
            {
                if (!_validarUsuario(entry))
                    return (false, "Datos incompletos.");

                var existe = _Contexto.Usuarios.Any(x => x.Nombre == entry.Nombre);

                if (existe)
                {

                    return (false, "El usuarios ya existe un usuarios con ese Nombre ");
                }

                Console.WriteLine($"usuarios agregado a la cola: {entry.Nombre}");

                _filaUsuario.Enqueue(entry);
                Console.WriteLine($"usuarios agregado a la cola: {entry.Nombre}");
                _notificar(entry);

                while (_filaUsuario.Count > 0)
                {

                    var usuariosEnProceso = _filaUsuario.Dequeue();
                    await _Contexto.Usuarios.AddAsync(usuariosEnProceso);
                    Console.WriteLine($"Procesando usuarios: {usuariosEnProceso.Nombre}");

                }

                await _Contexto.SaveChangesAsync();
                LimpiarCache();
                _notificar(new Usuario { Nombre = "Proceso de guardado completado" });

                return (true, "El usuarios se guardo Correctamente...");
            }
            catch (Exception ex)
            {
                return (false, "El usuarios no se pudo guardar...");
            }
        }
        public async Task<(bool IsSucces, string Message)> UpdateAsync(Usuario entry)
        {
            try
            {
                if (!_validarUsuario(entry))
                {
                    return (false, "Datos incompletos.");
                }

                var existe = _Contexto.Usuarios.Any(x => x.Nombre == entry.Nombre);
                if (existe)
                {

                    return (false, "El usuarios ya existe un usuarios con ese Nombre");
                }
                _Contexto.Usuarios.Update(entry);
                await _Contexto.SaveChangesAsync();
                LimpiarCache();

                _notificar(entry);


                return (true, "El usuarios se actualizo Correctamente...");
            }
            catch (Exception)
            {
                return (false, "El usuarios no se pudo Actualizar...");
            }
        }

        public async Task<(bool IsSucces, string Message)> DeleteAsync(int id)
        {
            try
            {
                var usuarios = await _Contexto.Usuarios.FindAsync(id);
                if (usuarios != null)
                {
                    _Contexto.Usuarios.Remove(usuarios);
                    await _Contexto.SaveChangesAsync();
                    LimpiarCache();
                    return (true, "El usuarios se elimino Correctamente...");
                }
                else
                {
                    return (false, "No se encontro el usuarios...");
                }

            }
            catch (Exception)
            {
                return (false, "El usuarios no se pudo eliminar...");
            }
        }

        public Usuario? ObtenerUsuarioPorNombre(string nombre)
        {
            return _Contexto.Usuarios.FirstOrDefault(u => u.Nombre == nombre);
        }
        public void AgregarUsuario(Usuario usuario)
        {
            _Contexto.Usuarios.Add(usuario);
            _Contexto.SaveChanges();
        }

        public Task<IEnumerable<Usuario>> GetCompletasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetPendientesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<double> GetPromedioCompletasAsync()
        {
            throw new NotImplementedException();
        }


    }
}
