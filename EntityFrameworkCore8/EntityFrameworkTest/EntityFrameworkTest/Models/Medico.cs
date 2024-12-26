namespace EntityFrameworkTest.Models
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Especialidad { get; set; }
        public DateTime Activo { get; set; }
    }
}
