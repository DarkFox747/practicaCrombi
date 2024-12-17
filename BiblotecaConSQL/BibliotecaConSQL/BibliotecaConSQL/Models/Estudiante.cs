namespace BibliotecaConSQL.Models
{
    public class Estudiante : Usuario
    {

        public Estudiante()
        {
            MaxLibrosPrestados = 3;
        }

        public Estudiante(string id, string nombre )
        {
            IDUsuarios = id;
            Nombre = nombre;
            MaxLibrosPrestados = 3;
        }
    }
}
