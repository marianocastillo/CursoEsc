using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using CursoAPI.Models;

namespace CursoEsc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly BdcursoContext _context;
        private readonly ILogger<CursoController> _logger;

        public CursoController(BdcursoContext context,   ILogger<CursoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            var cursos = await _context.Cursos.ToListAsync();
            return Ok(cursos);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return Ok(curso);
        }



        [HttpPost]
        public async Task<IActionResult> CreateCurso([FromBody] Curso curso)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Cursos.Add(curso);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCurso), new { id = curso.Iidcurso }, curso);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el curso.");
                return StatusCode(500, "Error al crear el curso.");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurso(int id, [FromBody] Curso curso)
        {
            var cursoExistente = await _context.Cursos.FindAsync(id);
            if (cursoExistente == null)
            {
                return NotFound();
            }

            // Actualizar solo las propiedades proporcionadas en el cuerpo de la solicitud
            cursoExistente.Nombre = curso.Nombre;
            cursoExistente.Descripcion = curso.Descripcion;
            // ... actualizar otras propiedades

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            Console.WriteLine($"Eliminando curso con ID: {id}");  // Verifica si el método llega al servidor
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            // Eliminar las secciones asociadas
            var secciones = _context.SeccionCursos.Where(s => s.Iidcurso == id).ToList();
            if (secciones.Any())
            {
                _context.SeccionCursos.RemoveRange(secciones);
            }

            // Eliminar el curso
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }





    }
}
