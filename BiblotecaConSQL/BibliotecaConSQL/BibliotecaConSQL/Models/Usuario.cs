namespace BibliotecaConSQL.Models
{
    public abstract class Usuario
    {
        public string IDUsuarios { get; set; }
        public string Nombre { get; set; }
        public List<Libro> LibrosPrestados { get; set; } = new List<Libro>();
        public DateTime? FechaInactivacion { get; set; }
        protected int MaxLibrosPrestados { get; set; }

        public virtual bool PuedePedirPrestado()
        {
            return FechaInactivacion == null && LibrosPrestados.Count < MaxLibrosPrestados;
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
