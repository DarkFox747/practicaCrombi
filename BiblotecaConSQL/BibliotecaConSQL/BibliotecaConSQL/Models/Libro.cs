namespace BibliotecaConSQL.Models
{
    public class Libro
    {
        public int IDLibros { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Cantidad { get; set; } = 0;
        public string Disponibilidad { get; set; } = "Disponible";
        public DateTime? FechaInactivacion { get; set; }

        public void PrestarLibro()
        {
            if (Cantidad > 0)
            {
                Cantidad -= 1;
                Disponibilidad = Cantidad > 0 ? "Disponible" : "No Disponible";

                if (Cantidad == 0)
                {
                    FechaInactivacion = DateTime.Now;
                }
            }
        }

        public void DevolverLibro()
        {
            Cantidad += 1;
            Disponibilidad = "Disponible";
            FechaInactivacion = null;
        }
    }
}
