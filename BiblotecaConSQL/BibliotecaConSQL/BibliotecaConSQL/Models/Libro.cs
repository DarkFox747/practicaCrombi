namespace BibliotecaConSQL.Models
{
    public class Libro
    {
        public string IDLibros { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Cantidad { get; set; } = 0;
        public bool Disponible { get; set; } = true;
        public DateTime? FechaInactivacion { get; set; }

        public void PrestarLibro()
        {
            if (Cantidad > 0)
            {
                Cantidad -= 1;
                if (Cantidad == 0)
                {
                    Disponible = false;
                    FechaInactivacion = DateTime.Now;
                }
            }
        }

        public void DevolverLibro()
        {
            Cantidad += 1;
            Disponible = true;
            FechaInactivacion = null;
        }
    }
}
