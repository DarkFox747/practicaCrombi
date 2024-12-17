namespace BibliotecaConSQL.Models
{
    public class Libro
    {
        //public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string IDLibros { get; set; }
        public bool Disponible { get; set; } = true;
        public int cantidad { get; set; }

        public void PrestarLibro()
        {
            cantidad -= 1;
            if (cantidad == 0) {
                Disponible = false;
            }            
        }

        public void DevolverLibro()
        {
            cantidad += 1;
            if (cantidad < 0 && Disponible == false) { Disponible = true; }
            
        }
    }
}
