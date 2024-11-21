namespace WebApplication1.Models
{
    public abstract class Usuario
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public List<Libro> LibrosPrestados { get; set; } = new List<Libro>();
        protected int MaxLibrosPrestados { get; set; }

        public virtual bool PuedePedirPrestado()
        {
            return LibrosPrestados.Count < MaxLibrosPrestados;
        }

        public virtual void AgregarLibroPrestado(Libro libro)
        {
            if (PuedePedirPrestado())
            {
                LibrosPrestados.Add(libro);
            }
            else
            {
                throw new Exception($"El usuario ha alcanzado el límite máximo de {MaxLibrosPrestados} libros.");
            }
        }

        public virtual void RemoverLibroPrestado(Libro libro)
        {
            LibrosPrestados.Remove(libro);
        }

        public virtual string ObtenerTipoUsuario()
        {
            return GetType().Name;
        }
    }
}
