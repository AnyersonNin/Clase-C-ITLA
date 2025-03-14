using Xunit;
using Moq;
using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using InfrastructureLayer.Repositorio.Comun;
using ApplicationLayer.Servicios.ServicioTarea;
using ApplicationLayer.Servicios.ServicioUsuario;
using GestorTareasAPI.Controllers;
namespace PruebaProyectoGestorTareas
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
            _mockProcesoTarea = new Mock<IProcesoComun<Tarea>>();
            _mockProcesoUsuario = new Mock<IProcesoComun<Usuario>>();
            _mockTareaServicio = new Mock<TareaServicio>(_mockProcesoTarea.Object);
            _mockUsuarioServicio = new Mock<UsuarioServicio>(_mockProcesoUsuario.Object);
            _tareaController = new TareaController(_mockTareaServicio.Object);
            _usuarioController = new UsuariosController(_mockUsuarioServicio.Object);
        }

        // 1️⃣ Inicio de sesión exitoso
        [Fact]
        public async Task Login_CredencialesCorrectas_DevuelveToken()
        {
            // Arrange
            var usuario = new Usuario { Nombre = "Admin", Contrasena = "1234", Role = "Admin" };
            _mockProcesoUsuario.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Usuario> { usuario });

            // Act
            var resultado = await _usuarioController.GetUsuarioAllAsync();

            // Assert
            Assert.NotNull(resultado.Value);
            Assert.True(resultado.Value.Succesful);
        }

        // 2️⃣ Inicio de sesión con credenciales incorrectas
        [Fact]
        public async Task Login_CredencialesIncorrectas_RetornaUnauthorized()
        {
            // Arrange
            _mockProcesoUsuario.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Usuario>());

            // Act
            var resultado = await _usuarioController.GetUsuarioAllAsync();

            // Assert
            Assert.False(resultado.Value.Succesful);
        }

        // 3️⃣ Creación de tarea válida
        [Fact]
        public async Task AgregarTarea_DatosValidos_RetornaExito()
        {
            // Arrange
            var nuevaTarea = new Tarea { Descripcion = "Nueva tarea", Estatus = "Pendiente" };
            _mockTareaServicio.Setup(s => s.AddTareaAllAsync(nuevaTarea))
                .ReturnsAsync(new Respuesta<string> { Succesful = true, Message = "Tarea agregada" });

            // Act
            var resultado = await _tareaController.AddTareaAllAsync(nuevaTarea);

            // Assert
            Assert.True(resultado.Value.Succesful);
            Assert.Equal("Tarea agregada", resultado.Value.Message);
        }

        // 4️⃣ Creación de tarea con datos inválidos
        [Fact]
        public async Task AgregarTarea_DatosInvalidos_RetornaError()
        {
            // Arrange
            var nuevaTarea = new Tarea { Descripcion = "", Estatus = "Pendiente" }; // Descripción vacía
            _mockTareaServicio.Setup(s => s.AddTareaAllAsync(nuevaTarea))
                .ReturnsAsync(new Respuesta<string> { Succesful = false, Message = "Datos inválidos" });

            // Act
            var resultado = await _tareaController.AddTareaAllAsync(nuevaTarea);

            // Assert
            Assert.False(resultado.Value.Succesful);
            Assert.Equal("Datos inválidos", resultado.Value.Message);
        }

        // 5️⃣ Obtener todas las tareas
        [Fact]
        public async Task ObtenerTodasLasTareas_RetornaLista()
        {
            // Arrange
            var tareas = new List<Tarea> { new Tarea { Id = 1, Descripcion = "Prueba", Estatus = "Pendiente" } };
            _mockTareaServicio.Setup(s => s.GetTareaAllAsync()).ReturnsAsync(new Respuesta<Tarea> { DataList = tareas, Succesful = true });

            // Act
            var resultado = await _tareaController.GetTareaAllAsync();

            // Assert
            Assert.True(resultado.Value.Succesful);
            Assert.NotEmpty(resultado.Value.DataList);
        }

        // 6️⃣ Eliminar tarea existente
        [Fact]
        public async Task EliminarTarea_Existente_RetornaExito()
        {
            // Arrange
            _mockTareaServicio.Setup(s => s.DeleteTareaAllAsync(1)).ReturnsAsync(new Respuesta<string> { Succesful = true, Message = "Tarea eliminada" });

            // Act
            var resultado = await _tareaController.DeleteTareaAllAsync(1);

            // Assert
            Assert.True(resultado.Value.Succesful);
            Assert.Equal("Tarea eliminada", resultado.Value.Message);
        }

        // 7️⃣ Eliminar tarea inexistente
        [Fact]
        public async Task EliminarTarea_NoExistente_RetornaError()
        {
            // Arrange
            _mockTareaServicio.Setup(s => s.DeleteTareaAllAsync(99)).ReturnsAsync(new Respuesta<string> { Succesful = false, Message = "Tarea no encontrada" });

            // Act
            var resultado = await _tareaController.DeleteTareaAllAsync(99);

            // Assert
            Assert.False(resultado.Value.Succesful);
            Assert.Equal("Tarea no encontrada", resultado.Value.Message);
        }

        // 8️⃣ Actualizar una tarea
        [Fact]
        public async Task ActualizarTarea_Existente_RetornaExito()
        {
            // Arrange
            var tareaActualizada = new Tarea { Id = 1, Descripcion = "Tarea Actualizada", Estatus = "Completada" };
            _mockTareaServicio.Setup(s => s.UpdateTareaAllAsync(tareaActualizada))
                .ReturnsAsync(new Respuesta<string> { Succesful = true, Message = "Tarea actualizada" });

            // Act
            var resultado = await _tareaController.UpdateTareaAllAsync(tareaActualizada);

            // Assert
            Assert.True(resultado.Value.Succesful);
            Assert.Equal("Tarea actualizada", resultado.Value.Message);
        }
        // 9️⃣ Calcular el porcentaje de tareas completadas
        [Fact]
        public async Task CalcularPromedioTareasCompletadas_DevuelveValorCorrecto()
        {
            // Arrange
            _mockTareaServicio.Setup(s => s.GetPromedioCompletasAsync())
                .ReturnsAsync(new Respuesta<object> { Succesful = true, SingleData = 75.0 });

            // Act
            var resultado = await _tareaController.GetPromedioCompletasAsync();

            // Assert
            Assert.True(resultado.Value.Succesful);
            Assert.Equal(75.0, resultado.Value.SingleData);
        }

        // 🔟 Recuperación de usuario por nombre
        [Fact]
        public async Task ObtenerUsuarioPorNombre_Existente_RetornaUsuario()
        {
            // Arrange
            var usuario = new Usuario { IdUsuario = 1, Nombre = "UsuarioPrueba", Role = "Admin" };
            _mockUsuarioServicio.Setup(s => s.GetUsuarioAllAsync())
                .ReturnsAsync(new Respuesta<Usuario> { DataList = new List<Usuario> { usuario }, Succesful = true });

            // Act
            var resultado = await _usuarioController.GetUsuarioAllAsync();

            // Assert
            Assert.True(resultado.Value.Succesful);
            Assert.NotNull(resultado.Value.DataList);
            Assert.Contains(resultado.Value.DataList, u => u.Nombre == "UsuarioPrueba");
        }
    }
}