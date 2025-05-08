using TrackingSystem.DataModel;

namespace TrackingSystem.BusinessLogic.Entities.Responses
{
    public class ResumenDeOrdenResponse

    {
        public int OrdenDeTrabajoId { get; set; }
        public DateTimeOffset FechaEstimadaDeEnvio { get; set; }
        public DateTimeOffset FechaEstimadaDeEntrega { get; set; }
        public DateTimeOffset? FechaDeEntrega { get; set; }
        public DateTimeOffset? FechaDeEnvio { get; set; }
        public DateTimeOffset FechaDeCreacion { get; set; }
        public string CodigoDeSeguimiento { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}
