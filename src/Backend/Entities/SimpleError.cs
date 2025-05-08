namespace TrackingSystem.Backend.Entities
{
    public class SimpleError
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public SimpleError(int codigo, string mensaje)
        {
            Codigo = codigo;
            Mensaje = mensaje;
        }
    }
}
