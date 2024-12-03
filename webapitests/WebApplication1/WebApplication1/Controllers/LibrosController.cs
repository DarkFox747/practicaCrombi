using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using Swashbuckle.AspNetCore.Annotations;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibrosController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet("libros")]
        public async Task<IActionResult> GetLibros()
        {
            var libros = await _libroService.GetAllLibrosAsync();
            return Ok(libros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibro(int id)
        {
            var libro = await _libroService.GetLibroByIdAsync(id);
            if (libro == null) return NotFound();
            return Ok(libro);
        }

        [HttpPost]
        public async Task<IActionResult> AddLibro([FromBody] Libro libro)
        {
            var added = await _libroService.AddLibroAsync(libro);
            if (!added) return BadRequest("No se pudo agregar el libro");
            return CreatedAtAction(nameof(GetLibro), new { id = libro.IDLibros }, libro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibro(int id, [FromBody] Libro libro)
        {
            if (id != libro.IDLibros) return BadRequest("ID no coincide");
            var updated = await _libroService.UpdateLibroAsync(libro);
            if (!updated) return NotFound();
            return NoContent();
        }
    }
}
