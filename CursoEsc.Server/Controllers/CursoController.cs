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
        public async Task<IActionResult> GetCursos()
        {
            try
            {
                var cursos = await _context.Cursos.ToListAsync();
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en la API: {ex.Message} - {ex.InnerException}");
            }
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        //{
        //    var cursos = await _context.Cursos.ToListAsync();
        //    return Ok(cursos);
        //}

        //        [HttpGet]
        //public async Task<ActionResult<IEnumerable<object>>> GetCursos()
        //{
        //    try
        //    {
        //        var baseUrl = $"{Request.Scheme}://{Request.Host}/"; // Obtiene la URL base del servidor

        //        var cursos = await _context.Cursos
        //            .Select(curso => new {
        //                curso.Iidcurso,
        //                curso.Nombre,
        //                curso.Descripcion,
        //                //curso.Categoria,
        //                curso.Precio,
        //                curso.Cupon,
        //                curso.Bhabilitado,
        //                ImagenUrl = curso.Imagen != null ? $"{baseUrl}imagenes/{curso.Imagen}" : null
        //            })
        //            .ToListAsync();

        //        return Ok(cursos);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error interno: {ex.Message}");
        //    }
        //}
















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
        public async Task<IActionResult> CreateCurso([FromForm] Curso curso, [FromForm] IFormFile? ImagenFile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Procesar la imagen si se envió
                if (ImagenFile != null)
                {
                    // Definir la carpeta donde se guardará la imagen (por ejemplo, wwwroot/images)
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Crear un nombre único para el archivo
                    var uniqueFileName = $"{Guid.NewGuid()}_{ImagenFile.FileName}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Guardar el archivo en el servidor
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImagenFile.CopyToAsync(stream);
                    }

                    // Asignar la ruta relativa al modelo
                    curso.Imagen = "/images/" + uniqueFileName;
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







        [HttpPut()]
        public async Task<IActionResult> PutCurso(int id, [FromForm] Curso curso)
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
