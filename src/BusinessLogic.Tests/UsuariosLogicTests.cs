using TrackingSystem.BusinessLogic.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Runtime.CompilerServices;
using System.Xml;
using TrackingSystem.BusinessLogic;
using TrackingSystem.BusinessLogic.Auth;
using TrackingSystem.BusinessLogic.Entities;
using TrackingSystem.BusinessLogic.Entities.Inputs;
using TrackingSystem.DataModel;
using Microsoft.Extensions.Caching.Memory;

namespace BusinessLogic.Tests
{
    public class UsuariosLogicTests : IClassFixture<GlobalEnvironmentTestFixture>
    {
        private readonly TrackingDataContext _context;
        private readonly GlobalEnvironmentTestFixture _fixture;

        public UsuariosLogicTests(GlobalEnvironmentTestFixture fixture)
        {
            _context = fixture.Context;
            _fixture = fixture;
        }

        #region GetUsuarioPorIdAsync
        [Fact]
        public async Task GetUsuarioPorId_DebeRetornarElUsuarioCorrecto_CuandoSeSuministrenUnIdCorrecto()
        {
            // Arrange
            var repository = new UsuariosLogic(_context);

            // Act
            var result = await repository.GetUsuarioPorIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("test@server.com", result.Email);
            Assert.Equal(1, result.UsuarioId);
        }

        [Fact]
        public async Task GetUsuarioPorId_DebeRetornarNulo_CuandoSeSuministrenUnUsuarioIdQueNoExiste()
        {
            // Arrange
            var logic = new UsuariosLogic(_context);

            // Act
            var result = await logic.GetUsuarioPorIdAsync(999);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task GetUsuarioPorId_DebeCancelar_SiSePideCancelacion()
        {
            // Arrange
            var logic = new UsuariosLogic(_context);
            var cancellationToken = new System.Threading.CancellationToken(true);
            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => logic.GetUsuarioPorIdAsync(1, cancellationToken));
        }
        #endregion

        #region GetUsuarioPorEmailAsync
        [Fact]
        public async Task GetUsuarioPorEmail_DebeRetornarElUsuarioCorrecto_CuandoSeSuministrenUnIdCorrecto()
        {
            // Arrange
            var repository = new UsuariosLogic(_context);

            // Act
            var result = await repository.GetUsuarioPorEmailAsync("test@server.com");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("test@server.com", result.Email);
            Assert.Equal(1, result.UsuarioId);
        }

        [Fact]
        public async Task GetUsuarioPorEmail_DebeRetornarNulo_CuandoSeSuministrenUnUsuarioIdQueNoExiste()
        {
            // Arrange
            var repository = new UsuariosLogic(_context);

            // Act
            var result = await repository.GetUsuarioPorEmailAsync("test999@server.com");

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task GetUsuarioPorEmail_DebeCancelar_SiSePideCancelacion()
        {
            // Arrange
            var logic = new UsuariosLogic(_context);
            var cancellationToken = new System.Threading.CancellationToken(true);
            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => logic.GetUsuarioPorEmailAsync("test999@server.com", cancellationToken));
        }
        #endregion

        #region Register
        [Fact]
        public async Task Register_DebeCrearElUsuarioCorrecto_CuandoSeSuministreLaDataCorrecta()
        {
            // Arrange
            var repository = new UsuariosLogic(_context);
            var userCount = _context.Usuarios.Count();
            // Act
            var input = new NuevoUsuarioInput
            {
                Apellidos = "Nuevo Apellido",
                Nombres = "Nuevo Nombre",
                Email = "test100@server.com",
                Password = "password",
                ConfirmacionDePassword = "password"
            };
            var result = await repository.RegistrarAsync(input);

            // Assert
            Assert.Equal(userCount + 1, _context.Usuarios.Count());
            Assert.Equal("Nuevo Apellido", result.Apellidos);

            // Cleanup
            _fixture.ResetData();
        }

        [Fact]
        public async Task Registrar_DebeLanzarException_CuandoPasswordsNoCoinciden()
        {
            // Arrange
            var repository = new UsuariosLogic(_context);
            var userCount = _context.Usuarios.Count();

            // Act - Assert
            var input = new NuevoUsuarioInput
            {
                Apellidos = "Nuevo Apellido",
                Nombres = "Nuevo Nombre",
                Email = "test100@server.com",
                Password = "password",
                ConfirmacionDePassword = "wrong_password"
            };

            var ex = await Assert.ThrowsAsync<SimpleException>(() => repository.RegistrarAsync(input));

            // Assert
            Assert.Equal(101, ex.Code);
        }

        [Fact]
        public async Task Registrar_DebeLanzarException_CuandoUsuarioYaExiste()
        {
            // Arrange
            var repository = new UsuariosLogic(_context);
            var userCount = _context.Usuarios.Count();

            // Act & Assert
            var input = new NuevoUsuarioInput
            {
                Apellidos = "Nuevo Apellido",
                Nombres = "Nuevo Nombre",
                Email = "test@server.com",
                Password = "password",
                ConfirmacionDePassword = "password"
            };

            var ex = await Assert.ThrowsAsync<SimpleException>(() => repository.RegistrarAsync(input));

            // Assert
            Assert.Equal(102, ex.Code);
        }
        [Fact]
        public async Task Registrar_DebeCancelar_SiSePideCancelacion()
        {
            // Arrange
            var logic = new UsuariosLogic(_context);
            var cancellationToken = new System.Threading.CancellationToken(true);
            // Act & Assert
            var input = new NuevoUsuarioInput
            {
                Apellidos = "Nuevo Apellido",
                Nombres = "Nuevo Nombre",
                Email = "test100@server.com",
                Password = "password",
                ConfirmacionDePassword = "password"
            };
            await Assert.ThrowsAsync<OperationCanceledException>(() => logic.RegistrarAsync(input, cancellationToken));
        }
        #endregion


    }
}