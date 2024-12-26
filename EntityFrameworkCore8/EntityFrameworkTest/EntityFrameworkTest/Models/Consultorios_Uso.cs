using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EntityFrameworkTest.Models
{
    public class Consultorios_Uso
    {
        public int Id { get; set; }
        public int IdConsultorio { get; set; }
        public Consultorio Consultorio { get; set; }
        public int IdMedico { get; set; }
        public Medico Medico { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaSalida { get; set; }
    }
}
