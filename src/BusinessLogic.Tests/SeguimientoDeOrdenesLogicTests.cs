using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyModel;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.BusinessLogic;
using TrackingSystem.BusinessLogic.Exceptions;
using TrackingSystem.DataModel;

namespace BusinessLogic.Tests
{
    public class SeguimientoDeOrdenesLogicTests : IClassFixture<GlobalEnvironmentTestFixture>
    {
        private readonly TrackingDataContext _context;
        private readonly GlobalEnvironmentTestFixture _fixture;

        public SeguimientoDeOrdenesLogicTests(GlobalEnvironmentTestFixture fixture)
        {
            _context = fixture.Context;
            _fixture = fixture;
        }

        #region GetOrdenesPorUsuarioAsync
        [Theory]
        [InlineData(1, 2)]  // Usuario 1 tiene 2 ordenes
        [InlineData(2, 0)]  // Usuario 2 no tiene ordenes
        [InlineData(10, 0)]  // Usuario 10 no existe
        public async Task GetOrdenesPorUsuario_DebeRetornarLasOrdenesCorrectas_CuandoSeSuministreUnUsuarioIdCorrecto(int userId, int expectedCount)
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            // Act
            var result = await logic.GetOrdenesAsync(userId, 999);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public async Task GetOrdenesPorUsuario_DebeRetornarLaCantidadCorrectaDeOrdenes_CuandoSeSuministreUnUsuarioIdYUnaCantidadCorrecta()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            // Act
            var result = await logic.GetOrdenesAsync(1, 1);
            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetOrdenesPorUsuario_DebeCancelar_SiSePideCancelacion()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            var cancellationToken = new System.Threading.CancellationToken(true);
            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => logic.GetOrdenesAsync(1, 1, cancellationToken));
        }
        #endregion

        #region GetOrdenPorCodigoDeSeguimiento
        [Fact]
        public async Task GetOrdenPorCodigoDeSeguimiento_DebeRetornarLaOrdenCorrecta_CuandoSeSuministreLosDatosCorrectos()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            // Act
            var result = await logic.GetOrdenPorCodigoDeSeguimientoAsync(1, "12345");
            // Assert
            Assert.NotNull(result);
            Assert.Equal("12345", result.CodigoDeSeguimiento);
        }
        [Fact]
        public async Task GetOrdenPorCodigoDeSeguimiento_DebeRetornarInformacionDeEnvio_CuandoSeSuministreLosDatosCorrectos()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            // Act
            var result = await logic.GetOrdenPorCodigoDeSeguimientoAsync(1, "12345");
            // Assert
            Assert.NotNull(result);
            Assert.Equal("12345", result.CodigoDeSeguimiento);
            Assert.NotNull(result.EnvioId);
            Assert.Equal(1, result.EnvioId);
        }
        [Fact]
        public async Task GetOrdenPorCodigoDeSeguimiento_DebeAgregarOrdenAlUsuario_CuandoSeSuministreLosDatosCorrectos()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            // Act
            // - Usuario 2 no tiene ordenes asignadas antes de llamar a este método
            var result = await logic.GetOrdenPorCodigoDeSeguimientoAsync(2, "67890");
            // Assert
            var ordenes = await logic.GetOrdenesAsync(2, 999);  // Este método es probado en otro test
            Assert.Single(ordenes);
        }
        [Fact]
        public async Task GetOrdenPorCodigoDeSeguimiento_DebeRetornarNulo_CuandoNoSeEncuentraElCodigoDeSeguimiento()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            // Act
            var result = await logic.GetOrdenPorCodigoDeSeguimientoAsync(1, "00000");
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task GetOrdenPorCodigoDeSeguimiento_LaUltimaOrdenConsultadaDebeAparecerPrimero_CuandoConsultaUnaOrden()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            // Act
            // -- Usuario 1 tiene 2 ordenes, en el order: 12345 y 67890
            var result = await logic.GetOrdenPorCodigoDeSeguimientoAsync(1, "67890");
            // Assert
            var ordenes = await logic.GetOrdenesAsync(1, 999);  // Este método es probado en otro test
            Assert.Collection(ordenes,
                item => Assert.Equal("67890", item.CodigoDeSeguimiento),
                item => Assert.Equal("12345", item.CodigoDeSeguimiento)
            );
        }

        [Fact]
        public async Task GetOrdenPorCodigoDeSeguimiento_DebeCancelar_SiSePideCancelacion()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            var cancellationToken = new System.Threading.CancellationToken(true);
            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => logic.GetOrdenPorCodigoDeSeguimientoAsync(1, "67890", cancellationToken));
        }
        #endregion

        #region DeleteOrdenPorUsuario
        [Fact]
        public async Task DeleteOrdenPorUsuario_DebeBorrarLaOrdenCorrecta_CuandoSeSuministreLosDatosCorrectos()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            // Act
            var result = await logic.DeleteOrdenPorUsuarioAsync(1, "12345");
            // Assert
            Assert.True(result);
            var ordenes = await logic.GetOrdenesAsync(1, 999);    // Este metodo es probado en otro test
            Assert.Single(ordenes);

            // Reset
            _fixture.ResetData();
        }
        [Fact]
        public async Task DeleteOrdenPorUsuario_DebeRetornarFalso_CuandoLaOrdenNoExiste()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            // Act
            var result = await logic.DeleteOrdenPorUsuarioAsync(1, "ABCDE");
            // Assert
            Assert.False(result);
        }
        [Fact]
        public async Task DeleteOrdenPorUsuario_DebeCancelar_SiSePideCancelacion()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            var cancellationToken = new System.Threading.CancellationToken(true);
            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => logic.DeleteOrdenPorUsuarioAsync(1, "67890", cancellationToken));
        }
        #endregion

        #region GetUbicacionActual
        [Fact]
        public async Task GetUbicacionActual_DebeRetornarDosValoresDiferentes_CuandoSeLlamaConsecutivamente()
        {
            // Arrange
            var cache = new MemoryCache(new MemoryCacheOptions());
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            // Act
            var firstCall = await logic.GetUbicacionActualAsync(1, "ABC5202024");
            var secondCall = await logic.GetUbicacionActualAsync(1, "ABC5202024");
            // Assert
            Assert.NotNull(firstCall);
            Assert.NotNull(secondCall);
            Assert.NotEqual(firstCall.Latitud, secondCall.Latitud);
            Assert.NotEqual(firstCall.Longitud, secondCall.Longitud);
        }
        [Fact]
        public async Task GetUbicacionActual_DebeRetornarNullo_CuandoSeLlamaUsandoUnCodigoDeSeguimientoQueNoSeEstaEmulando()
        {
            // Arrange
            var cache = new MemoryCache(new MemoryCacheOptions());
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            // Act
            var result = await logic.GetUbicacionActualAsync(1, "12345");
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task GetUbicacionActual_DebeCancelar_SiSePideCancelacion()
        {
            // Arrange
            var cache = Substitute.For<IMemoryCache>();
            var logic = new SeguimientoDeOrdenesLogic(_context, cache);
            var cancellationToken = new System.Threading.CancellationToken(true);
            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => logic.GetUbicacionActualAsync(1, "ABC5202024", cancellationToken));
        }
        #endregion
    }
}
