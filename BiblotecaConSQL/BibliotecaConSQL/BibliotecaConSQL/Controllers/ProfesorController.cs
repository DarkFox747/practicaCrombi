using BibliotecaConSQL.Models;
using BibliotecaConSQL.Services;
using Microsoft.AspNetCore.Mvc;


namespace BibliotecaConSQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public ProfesorController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetProfesores()
        {
            return Ok(_usuarioService.GetUsuariosPorTipo("Profesor"));
        }

        [HttpPost]
        public IActionResult AddProfesor([FromBody] Profesor profesor)
        {
            _usuarioService.AddUsuario(profesor, "Profesor");
            return Ok("Profesor agregado exitosamente");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfesor(string id)
        {
            _usuarioService.DeleteUsuario(id);
            return Ok("Profesor eliminado exitosamente");
        }
    }
}
