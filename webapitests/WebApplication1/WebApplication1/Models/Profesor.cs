namespace WebApplication1.Models
{
    public class Profesor : Usuario
    {
        public string Departamento { get; set; }

        public Profesor()
        {
            MaxLibrosPrestados = 5;
        }

        public Profesor(string id, string nombre, string departamento)
        {
            ID = id;
            Nombre = nombre;
            Departamento = departamento;
            MaxLibrosPrestados = 5;
        }

        public override bool PuedePedirPrestado()
        {
            return LibrosPrestados.Count < MaxLibrosPrestados;
        }
    }
}
