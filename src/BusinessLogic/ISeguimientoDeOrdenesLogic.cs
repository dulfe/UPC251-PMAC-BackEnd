using TrackingSystem.BusinessLogic.Entities.Responses;
using TrackingSystem.DataModel;

namespace TrackingSystem.BusinessLogic
{
    public interface ISeguimientoDeOrdenesLogic
    {
        Task<RastreoEnTiempoRealResponse?> GetUbicacionActualAsync(int userId, string codigoDeSeguimiento, CancellationToken cancellationToken = default);
        Task<bool> DeleteOrdenPorUsuarioAsync(int userId, string codigoDeSeguimiento, CancellationToken cancellationToken = default);
        Task<DetalleDeOrdenResponse?> GetOrdenPorCodigoDeSeguimientoAsync(int userId, string codigoDeSeguimiento, CancellationToken cancellationToken = default);
        Task<List<ResumenDeOrdenResponse>> GetOrdenesAsync(int userId, int? cantidad, CancellationToken cancellationToken = default);
    }
}
