using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Requests;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBibliotecaService _bibliotecaService;

        public BibliotecaController(IBibliotecaService bibliotecaService)
        {
            _bibliotecaService = bibliotecaService;
        }

        [HttpGet("libros")]
        public ActionResult<IEnumerable<Libro>> ObtenerLibros()
        {
            return Ok(_bibliotecaService.ObtenerTodosLosLibros());
        }

        [HttpGet("libros/{Id}")]
        public ActionResult<Libro> ObtenerLibro(string Id)
        {
            var libro = _bibliotecaService.ObtenerLibroPorId(Id);
            if (libro == null)
                return NotFound();
            return Ok(libro);
        }

        [HttpGet("usuarios")]
        public ActionResult<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            return Ok(_bibliotecaService.ObtenerTodosLosUsuarios());
        }

        [HttpGet("usuarios/{id}")]
        public ActionResult<Usuario> ObtenerUsuario(string id)
        {
            var usuario = _bibliotecaService.ObtenerUsuarioPorId(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPost("libros/prestar")]
        public ActionResult PrestarLibro([FromBody] PrestamoRequest request)
        {
            if (_bibliotecaService.PrestarLibro(request.Id, request.UsuarioId))
                return Ok();
            return BadRequest("No se pudo prestar el libro");
            
        }

        [HttpPost("libros/devolver")]
        public ActionResult DevolverLibro([FromBody] PrestamoRequest request)
        {
            if (_bibliotecaService.DevolverLibro(request.Id, request.UsuarioId))
                return Ok();
            return BadRequest("No se pudo devolver el libro");
        }

        [HttpPost("libros")]
        public ActionResult AgregarLibro([FromBody] Libro libro)
        {
            _bibliotecaService.AgregarLibro(libro);
            return CreatedAtAction(nameof(ObtenerLibro), new { Id = libro.Id }, libro);
        }

        [HttpPost("estudiantes")]
        public ActionResult RegistrarEstudiante([FromBody] RegistroEstudianteRequest request)
        {
            _bibliotecaService.RegistrarEstudiante(request.ID, request.Nombre);
            return CreatedAtAction(nameof(ObtenerUsuario), new { id = request.ID }, request);
        }

        [HttpPost("profesores")]
        public ActionResult RegistrarProfesor([FromBody] RegistroProfesorRequest request)
        {
            _bibliotecaService.RegistrarProfesor(request.ID, request.Nombre);
            return CreatedAtAction(nameof(ObtenerUsuario), new { id = request.ID }, request);
        }
    }
}
