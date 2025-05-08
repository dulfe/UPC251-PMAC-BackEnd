using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TrackingSystem.BusinessLogic.Entities.Responses;
using TrackingSystem.DataModel;

namespace TrackingSystem.BusinessLogic
{
    public class SeguimientoDeOrdenesLogic : ISeguimientoDeOrdenesLogic
    {
        public class LatLong
        {
            public decimal Lat { get; set; }
            public decimal Lng { get; set; }
        }

        private readonly TrackingDataContext _context;
        readonly IMemoryCache _memoryCache;
        readonly ILogger<SeguimientoDeOrdenesLogic>? _logger;
        // Simulacion de ubicacion
        readonly LatLong[] _simulatedLatLongs;

        public SeguimientoDeOrdenesLogic(TrackingDataContext context, IMemoryCache memoryCache, ILogger<SeguimientoDeOrdenesLogic>? logger = null)
        {
            this._logger = logger;
            this._memoryCache = memoryCache;
            _context = context;

            // Simulacion de ubicacion
            _simulatedLatLongs = new[]
            {
                new LatLong { Lat = -12.104526m, Lng = -76.979138m },
                new LatLong { Lat = -12.106939m, Lng = -76.978806m },
                new LatLong { Lat = -12.109079m, Lng = -76.978463m },
                new LatLong { Lat = -12.110180m, Lng = -76.977701m },
                new LatLong { Lat = -12.110023m, Lng = -76.976381m },
                new LatLong { Lat = -12.109929m, Lng = -76.974514m },
                new LatLong { Lat = -12.109824m, Lng = -76.972476m },
                new LatLong { Lat = -12.109069m, Lng = -76.970716m },
                new LatLong { Lat = -12.108009m, Lng = -76.969246m },
                new LatLong { Lat = -12.107054m, Lng = -76.968034m },
                new LatLong { Lat = -12.106310m, Lng = -76.966908m },
                new LatLong { Lat = -12.105617m, Lng = -76.966039m },
                new LatLong { Lat = -12.104883m, Lng = -76.965030m },
                new LatLong { Lat = -12.104369m, Lng = -76.964268m },
                new LatLong { Lat = -12.103687m, Lng = -76.963421m }
            };
        }

        public async Task<List<ResumenDeOrdenResponse>> GetOrdenesAsync(int userId, int? cantidad, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Recuperar las ordenes de trabajo del usuario
            var ordenPorUsuario = await _context.OrdenesPorUsuario
                .Include(m => m.OrdenDeTrabajo)
                .Include(m => m.OrdenDeTrabajo.Envios)
                .Where(m => m.UsuarioId == userId)
                .OrderByDescending(m => m.FechaDeUltimaConsulta)
                .Take(cantidad ?? 10)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            // Mapear las ordenes de trabajo a un DTO
            var result = ordenPorUsuario.Select(m => new ResumenDeOrdenResponse
            {
                OrdenDeTrabajoId = m.OrdenDeTrabajoId,
                FechaEstimadaDeEnvio = m.OrdenDeTrabajo.FechaEstimadaDeEnvio,
                CodigoDeSeguimiento = m.OrdenDeTrabajo.CodigoDeSeguimiento,
                Estado = m.OrdenDeTrabajo.Estado,
                FechaDeEntrega = m.OrdenDeTrabajo.Envios.FirstOrDefault()?.FechaDeEntrega,
                FechaDeEnvio = m.OrdenDeTrabajo.Envios.FirstOrDefault()?.FechaDeCreacion,
                FechaDeCreacion = m.FechaDeCreacion,
                FechaEstimadaDeEntrega = m.OrdenDeTrabajo.FechaEstimadaDeEntrega

            }).ToList();

            return result;
        }

        public async Task<DetalleDeOrdenResponse?> GetOrdenPorCodigoDeSeguimientoAsync(int userId, string codigoDeSeguimiento, CancellationToken cancellationToken = default)
        {
            // Recuperar la orden de trabajo por el codigo de seguimiento (ignorar el usuario actual)
            var orden = await _context.OrdenesDeTrabajo
                .Include(m => m.Fabrica)
                .Include(m => m.Envios)
                    .ThenInclude(m => m.Conductor)
                .Where(m => m.CodigoDeSeguimiento == codigoDeSeguimiento)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            // Si no se encuentra la orden de trabajo, devolver un 404
            if (orden == null)
            {
                return null;
            }

            // Agregar la orden de trabajo al usuario si no lo esta
            var orderPorUsuario = await _context.OrdenesPorUsuario
                .Where(m => m.OrdenDeTrabajoId == orden.OrdenDeTrabajoId && m.UsuarioId == userId)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (orderPorUsuario == null)
            {
                // No se encontro, agregarlo
                orderPorUsuario = new OrdenPorUsuario
                {
                    OrdenDeTrabajoId = orden.OrdenDeTrabajoId,
                    UsuarioId = userId,
                    FechaDeCreacion = DateTime.Now,
                    FechaDeUltimaConsulta = DateTime.Now
                };

                _context.OrdenesPorUsuario.Add(orderPorUsuario);
            }
            else
            {
                // Se encontro, actualizar la fecha de consulta
                orderPorUsuario.FechaDeUltimaConsulta = DateTime.Now;
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // Obtener el ultimo envio
            var ultimoEnvio = orden.Envios.OrderByDescending(m => m.FechaDeCreacion).FirstOrDefault();

            // Mapear la orden de trabajo a un DTO
            var result = new DetalleDeOrdenResponse
            {
                OrdenDeTrabajoId = orden.OrdenDeTrabajoId,
                FechaEstimadaDeTermino = orden.FechaEstimadaDeTermino,
                FechaEstimadaDeEnvio = orden.FechaEstimadaDeEnvio,
                FechaEstimadaDeEntrega = orden.FechaEstimadaDeEntrega,
                FechaDeCreacion = orden.FechaDeCreacion,
                ClienteId = orden.ClienteId,
                CodigoDeSeguimiento = orden.CodigoDeSeguimiento,
                DireccionDeEntrega = orden.DireccionDeEntrega,
                Estado = orden.Estado,
                LugarDeEntrega = orden.LugarDeEntrega,
                PesoEnKilos = orden.PesoEnKilos,
                FabricaId = orden.FabricaId,
                NombreDeLaFabrica = orden.Fabrica.Nombre,

                FechaDeEntrega = ultimoEnvio?.FechaDeEntrega,
                FechaDeEnvio = ultimoEnvio?.FechaDeCreacion,
                EnvioId = ultimoEnvio?.EnvioId,
                ConductorId = ultimoEnvio?.ConductorId,
                ConductorApellidos = ultimoEnvio?.Conductor.Apellidos,
                ConductorNombres = ultimoEnvio?.Conductor.Nombres,
                ConductorTelefono = ultimoEnvio?.Conductor.Telefono
            };

            return result;
        }

        public async Task<bool> DeleteOrdenPorUsuarioAsync(int userId, string codigoDeSeguimiento, CancellationToken cancellationToken = default)
        {
            // Recuperar OrdenPorUsuario basado en el codigo de seguimiento
            var orden = await _context.OrdenesPorUsuario
                .Where(m => m.OrdenDeTrabajo.CodigoDeSeguimiento == codigoDeSeguimiento && m.UsuarioId == userId)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            // Si no se encuentra la orden de trabajo, devolver false
            if (orden == null)
            {
                return false;
            }

            _context.OrdenesPorUsuario.Remove(orden);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return true;
        }

        public async Task<RastreoEnTiempoRealResponse?> GetUbicacionActualAsync(int userId, string codigoDeSeguimiento, CancellationToken cancellationToken = default)
        {
            // TODO ESTO ES UNA SIMULACION DE UBICACION
            // Para una aplicacion real, se deberia recuperar la ubicacion actual del envio de la base de datos
            // Y esta informacion deberia ser actualizada por un receptor de GPS que este ubicada en el vehiculo
            // que transporta la orden de trabajo

            _logger?.LogDebug("GetUbicacionActual:CodigoDeSeguimiento={0}", codigoDeSeguimiento);

            // Esta simulación solo funciona con un solo codigo de seguimiento
            if (codigoDeSeguimiento != "ABC5202024")
            {
                _logger?.LogDebug("GetUbicacionActual:NOT SUPPORTED");
                return await Task.FromResult<RastreoEnTiempoRealResponse?>(null);
            }

            cancellationToken.ThrowIfCancellationRequested();

            // Obtener la ultima ubicación reportada
            if (!_memoryCache.TryGetValue("LastPostReported", out int lastPostReported))
            {
                lastPostReported = 0;
            }

            _logger?.LogDebug("GetUbicacionActual:LastPostReported={0}", lastPostReported);

            // Obtener la siguiente ubicación
            int nextPost = lastPostReported + 1;

            if (nextPost >= _simulatedLatLongs.Length)
            {
                nextPost = 0;
            }

            _logger?.LogDebug("GetUbicacionActual:NextPost={0}", nextPost);

            // Actualizar la ultima ubicación reportada
            _memoryCache.Set("LastPostReported", nextPost);
            //_memoryCache.Set("LastPostReported", lastPostReported, TimeSpan.FromMinutes(5));

            // Generar resultado
            var location = _simulatedLatLongs[nextPost];
            var result = new RastreoEnTiempoRealResponse
            {
                Latitud = location.Lat,
                Longitud = location.Lng,
                FechaDeCreacion = DateTime.Now,
                CodigoDeSeguimiento = codigoDeSeguimiento
            };

            return result;
        }
    }
}
