using Moq;
using DomainLayer.Models;
using InfrastructureLayer.Repositorio.Comun;
using ApplicationLayer.Servicios.ServicioTarea;
using ApplicationLayer.Servicios.ServicioUsuario;
using GestorTareasAPI.Controllers;

namespace PruebasxUnitGestorTareas
{
    public class GestorTareasPruebas
    {
        private readonly Mock<IProcesoComun<Tarea>> _mockProcesoTarea;
        private readonly Mock<IProcesoComun<Usuario>> _mockProcesoUsuario;
        private readonly TareaServicio _tareaServicio;
        private readonly UsuarioServicio _usuarioServicio;
        private readonly TareaController _tareaController;
        private readonly UsuariosController _usuarioController;
        public GestorTareasPruebas()
        {
            _mockProcesoTarea = new Mock<IProcesoComun<Tarea>>();
            _mockProcesoUsuario = new Mock<IProcesoComun<Usuario>>();
            _tareaServicio = new TareaServicio(_mockProcesoTarea.Object);
            _usuarioServicio = new UsuarioServicio(_mockProcesoUsuario.Object);

            _tareaController = new TareaController(_tareaServicio);
            _usuarioController = new UsuariosController(_usuarioServicio);
        }

        [Fact]
        public async Task Login_CredencialesCorrectas_DevuelveToken()
        {
            var usuario = new Usuario { Nombre = "Admin", Contrasena = "1234", Role = "Admin" };
            _mockProcesoUsuario.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Usuario> { usuario });

            var resultado = await _usuarioController.GetUsuarioAllAsync();

            Assert.NotNull(resultado.Value);
            Assert.True(resultado.Value.Succesful);
        }

        [Fact]
        public async Task ObtenerTareaPorId_Existente_RetornaTarea()
        {
            var tarea = new Tarea { Id = 1, Descripcion = "Tarea de prueba", Estatus = "Pendiente" };
            _mockProcesoTarea.Setup(s => s.GetIdAsync(1)).ReturnsAsync(tarea);

            var resultado = await _tareaController.GetTareaByIdAllAsync(1);

            Assert.NotNull(resultado.Value);
            Assert.True(resultado.Value.Succesful);
            Assert.Equal(1, resultado.Value.SingleData.Id);
        }
        [Fact]
        public async Task ActualizarUsuario_Existente_RetornaExito()
        {
            var usuarioActualizado = new Usuario { IdUsuario = 1, Nombre = "Usuario Actualizado", Role = "Admin" };
            _mockProcesoUsuario.Setup(s => s.UpdateAsync(usuarioActualizado))
                .ReturnsAsync((true, "Usuario actualizado"));

            var resultado = await _usuarioController.UpdateTareaAllAsync(usuarioActualizado);

            Assert.NotNull(resultado.Value);
            Assert.True(resultado.Value.Succesful);
            Assert.Equal("Usuario actualizado", resultado.Value.Message);
        }


        [Fact]
        public async Task ObtenerUsuarios_RetornaLista()
        {
            var usuarios = new List<Usuario> { new Usuario { IdUsuario = 1, Nombre = "Usuario1", Role = "User" } };
            _mockProcesoUsuario.Setup(s => s.GetAllAsync()).ReturnsAsync(usuarios);

            var resultado = await _usuarioController.GetUsuarioAllAsync();

            Assert.NotNull(resultado.Value);
            Assert.True(resultado.Value.Succesful);
            Assert.NotEmpty(resultado.Value.DataList);
        }

        [Fact]
        public async Task ObtenerTodasLasTareas_RetornaLista()
        {
            var tareas = new List<Tarea>
            {
              new Tarea { Id = 1, Descripcion = "Prueba", Estatus = "Pendiente" }
            };

            _mockProcesoTarea.Setup(s => s.GetAllAsync()).ReturnsAsync(tareas);

            var resultado = await _tareaController.GetTareaAllAsync();

            Assert.NotNull(resultado.Value);
            Assert.True(resultado.Value.Succesful);
            Assert.NotEmpty(resultado.Value.DataList);
        }

        [Fact]
        public async Task EliminarTarea_Existente_RetornaExito()
        {
            _mockProcesoTarea.Setup(s => s.DeleteAsync(1))
                .ReturnsAsync((true, "Tarea eliminada"));

            var resultado = await _tareaController.DeleteTareaAllAsync(1);

            Assert.NotNull(resultado.Value);
            Assert.True(resultado.Value.Succesful);
            Assert.Equal("Tarea eliminada", resultado.Value.Message);
        }

        [Fact]
        public async Task EliminarTarea_NoExistente_RetornaError()
        {
            _mockProcesoTarea.Setup(s => s.DeleteAsync(99))
        .ReturnsAsync((false, "Tarea no encontrada"));

            var resultado = await _tareaController.DeleteTareaAllAsync(99);

            Assert.NotNull(resultado.Value);
            Assert.False(resultado.Value.Succesful);
            Assert.Equal("Tarea no encontrada", resultado.Value.Message);
        }

        [Fact]
        public async Task ActualizarTarea_Existente_RetornaExito()
        {
            var tareaActualizada = new Tarea { Id = 1, Descripcion = "Tarea Actualizada", Estatus = "Completada" };

            _mockProcesoTarea.Setup(s => s.UpdateAsync(tareaActualizada))
                .ReturnsAsync((true, "Tarea actualizada"));

            var resultado = await _tareaController.UpdateTareaAllAsync(tareaActualizada);

            Assert.True(resultado.Value.Succesful);
            Assert.Equal("Tarea actualizada", resultado.Value.Message);
        }

        [Fact]
        public async Task CalcularPromedioTareasCompletadas_DevuelveValorCorrecto()
        {
            _mockProcesoTarea.Setup(s => s.GetPromedioCompletasAsync())
           .ReturnsAsync(75.0);

            var resultado = await _tareaController.GetPromedioCompletasAsync();

            Assert.NotNull(resultado.Value);
            Assert.True(resultado.Value.Succesful);
            Assert.Equal(75.0, resultado.Value.SingleData);
        }

        [Fact]
        public async Task ObtenerUsuarioPorNombre_Existente_RetornaUsuario()
        {
            var usuario = new Usuario { IdUsuario = 1, Nombre = "UsuarioPrueba", Role = "Admin" };

            _mockProcesoUsuario.Setup(s => s.GetAllAsync())
                .ReturnsAsync(new List<Usuario> { usuario });

            var resultado = await _usuarioController.GetUsuarioAllAsync();

            Assert.NotNull(resultado.Value);
            Assert.True(resultado.Value.Succesful);
            Assert.Contains(resultado.Value.DataList, u => u.Nombre == "UsuarioPrueba");
        }
    }
} 
    
