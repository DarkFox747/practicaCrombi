namespace WebApplication1.Models
{
    public class Profesor : Usuario
    {
      

        public Profesor(string id, string nombre)
        {
            IDUsuarios = id;
            Nombre = nombre;
            MaxLibrosPrestados = 5;
        }

        public override bool PuedePedirPrestado()
        {
            return LibrosPrestados.Count < MaxLibrosPrestados;
        }
    }
}
