namespace TrackingSystem.BusinessLogic.Entities.Responses
{
    public class UsuarioResponse
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; } = null!;

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;
        public DateTimeOffset FechaDeCreacion { get; set; }

        public string Estado { get; set; } = null!;
    }
}
