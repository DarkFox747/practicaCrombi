namespace WebApplication1.Models
{
    public class Estudiante : Usuario
    {

        public Estudiante()
        {
            MaxLibrosPrestados = 3;
        }

        public Estudiante(string id, string nombre )
        {
            ID = id;
            Nombre = nombre;
            MaxLibrosPrestados = 3;
        }
    }
}
