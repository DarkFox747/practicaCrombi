using BibliotecaConSQL.Models;
using BibliotecaConSQL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaConSQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public EstudianteController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("GetEstudiantes")]
        public IActionResult GetEstudiantes()
        {
            var estudiantes = _usuarioService.GetUsuariosPorTipo("Estudiante");
            return Ok(estudiantes);
        }

        [HttpPost]
        public IActionResult AddEstudiante([FromBody] Estudiante Estudiante)
        {
            _usuarioService.AddUsuario(Estudiante, "Estudiante");
            return Ok("Estudiante agregado exitosamente");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEstudiante(string id)
        {
            _usuarioService.DeleteUsuario(id);
            return Ok("Estudiante eliminado exitosamente");
        }
    }
}
