using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTest.Models
{
    public class Usuarios
    {
        
        public int IdUsuarios { get; set; } 
       
        public string Nombre { get; set; }
        
        public string Email { get; set; }
        
        public int Edad { get; set; }

        public int ObraSocialId { get; set; }
        public ObraSocial ObraSocial { get; set; }


    }
}
