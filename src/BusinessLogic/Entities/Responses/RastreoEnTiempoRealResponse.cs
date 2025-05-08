using TrackingSystem.DataModel;

namespace TrackingSystem.BusinessLogic.Entities.Responses
{
    public class RastreoEnTiempoRealResponse
    {
        public string CodigoDeSeguimiento { get; set; } = null!;

        public decimal Latitud { get; set; }

        public decimal Longitud { get; set; }

        public DateTimeOffset FechaDeCreacion { get; set; }
    }
}
