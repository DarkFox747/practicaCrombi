namespace WebApplication1.Models
{
    public class Libro
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public bool Disponible { get; set; } = true;

        public void PrestarLibro()
        {
            Disponible = false;
        }

        public void DevolverLibro()
        {
            Disponible = true;
        }
    }
}
