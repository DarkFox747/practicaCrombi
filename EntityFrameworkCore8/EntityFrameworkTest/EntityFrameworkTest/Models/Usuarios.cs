using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTest.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuarios { get; set; } 
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Edad { get; set; }

        public int ObraSocial { get; set; }

    }
}
