using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursoAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoEsc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly BdcursoContext _context;

        public CursoController(BdcursoContext context)
        {
            _context = context;
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
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCurso), new { id = curso.Iidcurso }, curso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, [FromBody] Curso curso)
        {
            if (id != curso.Iidcurso)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cursos.Any(c => c.Iidcurso == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            // Buscar y eliminar secciones asociadas
            var secciones = _context.SeccionCursos.Where(s => s.Iidcurso == id).ToList();
            if (secciones.Any())
            {
                _context.SeccionCursos.RemoveRange(secciones);
            }

            // Ahora sí, eliminar el curso
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }







    }
}
