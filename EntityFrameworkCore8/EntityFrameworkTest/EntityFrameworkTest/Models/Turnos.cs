namespace EntityFrameworkTest.Models
{
    public class Turnos
    {
        public int IdTurno { get; set; }
        public int Idusuario { get; set; }
        public Usuarios Usuarios { get; set; }
        public int IdMedico { get; set; }
        public Medico Medico { get; set; }
        public DateTime fecha { get; set; }
        public bool activo { get; set; }

    }
}
