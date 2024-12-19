using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTest.Models
{
    public class Usuarios
    {
        [Key]
        public Guid IdUsuarios { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
