using System.ComponentModel.Design;

namespace EntityFrameworkTest.Models
{
    public class Medico_Obrasocial
    {
        public int IdTabla { get; set; }
        public int IdMedico {  get; set; }
        public Medico Medico { get; set; }
        public int IdObraSocial { get; set; }
        public ObraSocial ObraSocial { get; set; }
        public bool activo { get; set; }
    }
}
