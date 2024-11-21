namespace WebApplication1.Models
{
    public class Profesor : Usuario
    {
        

        public Profesor()
        {
            MaxLibrosPrestados = 5;
        }

        public Profesor(string id, string nombre)
        {
            ID = id;
            Nombre = nombre;
            MaxLibrosPrestados = 5;
        }

        public override bool PuedePedirPrestado()
        {
            return LibrosPrestados.Count < MaxLibrosPrestados;
        }
    }
}
