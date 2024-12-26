using System.ComponentModel.Design;

namespace EntityFrameworkTest.Models
{
    public class Medico_Obrasocial
    {
        public int Id { get; set; }
        public int IdMedico {  get; set; }
        public int IdObraSocial { get; set; }
        public bool activo { get; set; }
    }
}
