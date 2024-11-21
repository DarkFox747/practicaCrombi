namespace WebApplication1.Models
{
    public class Estudiante : Usuario
    {
        public string Carrera { get; set; }

        public Estudiante()
        {
            MaxLibrosPrestados = 3;
        }

        public Estudiante(string id, string nombre, string carrera)
        {
            ID = id;
            Nombre = nombre;
            Carrera = carrera;
            MaxLibrosPrestados = 3;
        }
    }
}
