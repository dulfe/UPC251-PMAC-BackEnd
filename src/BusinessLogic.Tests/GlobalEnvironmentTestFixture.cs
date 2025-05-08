using Microsoft.EntityFrameworkCore;
using TrackingSystem.BusinessLogic.Auth;
using TrackingSystem.DataModel;

namespace BusinessLogic.Tests
{
    public class GlobalEnvironmentTestFixture : IDisposable
    {
        #region IDisposable
        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Context != null)
                        Context.Dispose();
                }
            }
            disposed = true;
        }

        ~GlobalEnvironmentTestFixture()
        {
            Dispose(false);
        }
        #endregion

        public TrackingDataContext Context;

        public GlobalEnvironmentTestFixture()
        {
            InitData();
        }

        public void ResetData()
        {
            InitData(true);
        }

        private void InitData(bool disponseOldDb = false)
        {

            Console.WriteLine("InitData");
            if (disponseOldDb)
            {
                Context.Dispose();
            }

            var options = new DbContextOptionsBuilder<TrackingDataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            Context = new TrackingDataContext(options);

            var hashedPassword = AuthenticationHelper.GetPasswordHash("password");

            Context.Usuarios.Add(
                new Usuario
                {
                    Apellidos = "Test",
                    Nombres = "Test",
                    Email = "test@server.com",
                    PasswordHash = hashedPassword,
                    Estado = "A",
                    FechaDeCreacion = DateTime.Now,
                }
            );
            Context.Usuarios.Add(
                new Usuario
                {
                    Apellidos = "Test 2",
                    Nombres = "Test 2",
                    Email = "test2@server.com",
                    PasswordHash = hashedPassword,
                    Estado = "A",
                    FechaDeCreacion = DateTime.Now,
                }
                );

            Context.Conductores.Add(
                new Conductor
                {
                    Apellidos = "Apellido 1",
                    Nombres = "Nombre 1",
                    Telefono = "1234567890",
                    Estado = "A",
                    FechaDeCreacion = DateTime.Now,
                }
            );
            Context.Conductores.Add(
                new Conductor
                {
                    Apellidos = "Apellido 2",
                    Nombres = "Nombre 2",
                    Telefono = "0987654321",
                    Estado = "A",
                    FechaDeCreacion = DateTime.Now,
                }
            );
            Context.Fabricas.Add(
                new Fabrica
                {
                    Nombre = "Fabrica 1",
                    FechaDeCreacion = DateTime.Now,
                });
            Context.Fabricas.Add(
                new Fabrica
                {
                    Nombre = "Fabrica 2",
                    FechaDeCreacion = DateTime.Now,
                }
            );
            Context.Clientes.Add(new Cliente
            {
                Empresa = "Empresa 1",
                NombreDelRepresentante = "Representante 1",
                ApellidosDelRepresentante = "Apellido 1",
                Cargo = "Cargo 1",
                Estado = "A",
                FechaDeCreacion = DateTime.Now,
            });
            Context.Clientes.Add(new Cliente
            {
                Empresa = "Empresa 2",
                NombreDelRepresentante = "Representante 2",
                ApellidosDelRepresentante = "Apellido 2",
                Cargo = "Cargo 2",
                Estado = "A",
                FechaDeCreacion = DateTime.Now,
            });

            Context.SaveChanges();

            Context.OrdenesDeTrabajo.Add(
                new OrdenDeTrabajo
                {
                    CodigoDeSeguimiento = "12345",
                    Descripcion = "Descripcion 1",
                    DireccionDeEntrega = "Direccion 1",
                    Estado = "A",
                    LugarDeEntrega = "Lugar 1",
                    PesoEnKilos = 10,
                    ClienteId = 1,
                    FabricaId = 1,
                    FechaDeCreacion = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
                    FechaEstimadaDeEntrega = new DateTimeOffset(2024, 1, 10, 0, 0, 0, TimeSpan.Zero),
                    FechaEstimadaDeTermino = new DateTimeOffset(2024, 1, 5, 0, 0, 0, TimeSpan.Zero),
                    FechaEstimadaDeEnvio = new DateTimeOffset(2024, 1, 6, 0, 0, 0, TimeSpan.Zero),
                }
            );
            Context.OrdenesDeTrabajo.Add(
                new OrdenDeTrabajo
                {
                    CodigoDeSeguimiento = "67890",
                    Descripcion = "Descripcion 2",
                    DireccionDeEntrega = "Direccion 2",
                    Estado = "A",
                    LugarDeEntrega = "Lugar 2",
                    PesoEnKilos = 20,
                    ClienteId = 2,
                    FabricaId = 1,
                    FechaDeCreacion = new DateTimeOffset(2024, 2, 1, 0, 0, 0, TimeSpan.Zero),
                    FechaEstimadaDeEntrega = new DateTimeOffset(2024, 2, 10, 0, 0, 0, TimeSpan.Zero),
                    FechaEstimadaDeTermino = new DateTimeOffset(2024, 2, 5, 0, 0, 0, TimeSpan.Zero),
                    FechaEstimadaDeEnvio = new DateTimeOffset(2024, 2, 6, 0, 0, 0, TimeSpan.Zero),
                }
            );

            Context.SaveChanges();

            Context.Envios.Add(
                new Envio
                {
                    ConductorId = 1,
                    FechaDeCreacion = new DateTimeOffset(2024, 1, 6, 0, 0, 0, TimeSpan.Zero),
                    FechaDeEntrega = new DateTimeOffset(2024, 1, 11, 0, 0, 0, TimeSpan.Zero),
                    OrdenDeTrabajoId = 1,
                    EnvioId = 1,
                    Estado = "A"
                }
            );

            Context.SaveChanges();
            Context.OrdenesPorUsuario.Add(
                new OrdenPorUsuario
                {
                    OrdenDeTrabajoId = 1,
                    UsuarioId = 1,
                    FechaDeCreacion = new DateTimeOffset(2024, 2, 1, 0, 0, 0, TimeSpan.Zero),
                    FechaDeUltimaConsulta = new DateTimeOffset(2024, 2, 1, 0, 0, 0, TimeSpan.Zero)
                }
            );
            Context.OrdenesPorUsuario.Add(
                new OrdenPorUsuario
                {
                    OrdenDeTrabajoId = 2,
                    UsuarioId = 1,
                    FechaDeCreacion = new DateTimeOffset(2024, 2, 1, 0, 0, 0, TimeSpan.Zero),
                    FechaDeUltimaConsulta = new DateTimeOffset(2024, 2, 1, 0, 0, 0, TimeSpan.Zero)
                }
            );

            Context.SaveChanges();

        }
    }
}