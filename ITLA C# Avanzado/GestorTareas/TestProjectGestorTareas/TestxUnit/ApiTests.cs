using Xunit;
using Moq;
using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using InfrastructureLayer.Repositorio.Comun;
using ApplicationLayer.Servicios.ServicioTarea;
using ApplicationLayer.Servicios.ServicioUsuario;
using GestorTareasAPI.Controllers;
namespace InfrastructureLayer.TestxUnit
{
    public class ApiTests
    {
        private readonly Mock<TareaServicio> _mockTareaServicio;
        private readonly Mock<UsuarioServicio> _mockUsuarioServicio;
        private readonly Mock<IProcesoComun<Tarea>> _mockProcesoTarea;
        private readonly Mock<IProcesoComun<Usuario>> _mockProcesoUsuario;
        private readonly TareaController _tareaController;
        private readonly UsuariosController _usuarioController;

        public ApiTests()
        {
            _mockTareaServicio = new Mock<TareaServicio>(_mockProcesoTarea.Object);
            _mockUsuarioServicio = new Mock<UsuarioServicio>(_mockProcesoUsuario.Object);
            _tareaController = new TareaController(_mockTareaServicio.Object);
            _usuarioController = new UsuariosController(_mockUsuarioServicio.Object);
        }

        [Fact]
        public async Task ObtenerTodasLasTareas_RetornaLista()
        {
            // Arrange
            var tareas = new List<Tarea> { new Tarea { Id = 1, Descripcion = "Prueba", Estatus = "Pendiente" } };
            _mockTareaServicio.Setup(s => s.GetTareaAllAsync()).ReturnsAsync(new Respuesta<Tarea> { DataList = tareas, Succesful = true });

            // Act
            var resultado = await _tareaController.GetTareaAllAsync();

            // Assert
            var actionResult = Assert.IsType<ActionResult<Respuesta<Tarea>>>(resultado);
            Assert.True(actionResult.Value.Succesful);
        }

        [Fact]
        public async Task AgregarTarea_ValidaEntrada()
        {
            // Arrange
            var nuevaTarea = new Tarea { Descripcion = "Nueva tarea", Estatus = "Pendiente" };
            _mockTareaServicio.Setup(s => s.AddTareaAllAsync(nuevaTarea)).ReturnsAsync(new Respuesta<string> { Succesful = true, Message = "Tarea agregada" });

            // Act
            var resultado = await _tareaController.AddTareaAllAsync(nuevaTarea);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Respuesta<string>>>(resultado);
            Assert.True(actionResult.Value.Succesful);
            Assert.Equal("Tarea agregada", actionResult.Value.Message);
        }

        [Fact]
        public async Task ObtenerUsuarioPorNombre_RetornaUsuario()
        {
            // Arrange
            var usuario = new Usuario { IdUsuario = 1, Nombre = "UsuarioPrueba", Role = "Admin" };
            _mockUsuarioServicio.Setup(s => s.GetUsuarioAllAsync()).ReturnsAsync(new Respuesta<Usuario> { DataList = new List<Usuario> { usuario }, Succesful = true });

            // Act
            var resultado = await _usuarioController.GetUsuarioAllAsync();

            // Assert
            var actionResult = Assert.IsType<ActionResult<Respuesta<Usuario>>>(resultado);
            Assert.True(actionResult.Value.Succesful);
        }

        [Fact]
        public async Task EliminarTarea_RetornaExito()
        {
            // Arrange
            _mockTareaServicio.Setup(s => s.DeleteTareaAllAsync(1)).ReturnsAsync(new Respuesta<string> { Succesful = true, Message = "Tarea eliminada" });

            // Act
            var resultado = await _tareaController.DeleteTareaAllAsync(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Respuesta<string>>>(resultado);
            Assert.True(actionResult.Value.Succesful);
            Assert.Equal("Tarea eliminada", actionResult.Value.Message);
        }

        [Fact]
        public async Task ValidarAutenticacionUsuario()
        {
            // Arrange
            var usuario = new Usuario { Nombre = "UsuarioPrueba", Contrasena = "1234", Role = "Admin" };
            var mockRepo = new Mock<IProcesoComun<Usuario>>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Usuario> { usuario });

            var servicio = new UsuarioServicio(mockRepo.Object);
            var resultado = await servicio.GetUsuarioAllAsync();

            // Assert
            Assert.True(resultado.Succesful);
            Assert.Contains(resultado.DataList, u => u.Nombre == "UsuarioPrueba");
        }
    }
}