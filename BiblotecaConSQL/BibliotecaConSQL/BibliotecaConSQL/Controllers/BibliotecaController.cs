using BibliotecaConSQL.Models;
using BibliotecaConSQL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaConSQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBibliotecaService _bibliotecaService;

        public BibliotecaController(IBibliotecaService bibliotecaService)
        {
            _bibliotecaService = bibliotecaService;
        }

        [HttpGet("libros")]
        public IActionResult GetLibros()
        {
            var libros = _bibliotecaService.ObtenerLibros();
            return Ok(libros);
        }

        [HttpPost("libros")]
        public IActionResult AgregarLibro([FromBody] Libro libro)
        {
            _bibliotecaService.AgregarLibro(libro);
            return Ok("Libro agregado correctamente.");
        }

        [HttpDelete("libros/{id}")]
        public IActionResult EliminarLibro(string id)
        {
            _bibliotecaService.EliminarLibro(id);
            return Ok("Libro eliminado correctamente.");
        }

        [HttpPost("libros/{id}")]
        public IActionResult DevolverLibro(string id)
        {
            _bibliotecaService.DevolverLibro(id);
            return Ok("Libro fue devuelto correctamente.");
        }
    }
}
