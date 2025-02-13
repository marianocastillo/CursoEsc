using Microsoft.AspNetCore.Mvc;
using CursoAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CursoEsc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaCursoController : ControllerBase
    {
        private readonly BdcursoContext _context;

        public CategoriaCursoController(BdcursoContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaCurso
        [HttpGet]
        public ActionResult<IEnumerable<CategoriaCurso>> GetCategorias()
        {
            return _context.CategoriaCursos.ToList();
        }

        // GET: api/CategoriaCurso/5
        [HttpGet("{id}")]
        public ActionResult<CategoriaCurso> GetCategoria(int id)
        {
            var categoria = _context.CategoriaCursos.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }

        // POST: api/CategoriaCurso
        [HttpPost]
        public ActionResult<CategoriaCurso> PostCategoria(CategoriaCurso categoria)
        {
            _context.CategoriaCursos.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Iidcategoriacurso }, categoria);
        }

        // PUT: api/CategoriaCurso/5
        [HttpPut("{id}")]
        public IActionResult PutCategoria(int id, CategoriaCurso categoria)
        {
            if (id != categoria.Iidcategoriacurso)
            {
                return BadRequest();
            }

            // Verifica si la categoría existe en la base de datos
            var categoriaExistente = _context.CategoriaCursos.Find(id);
            if (categoriaExistente == null)
            {
                return NotFound();
            }

            // Actualiza solo los campos necesarios
            categoriaExistente.Nombre = categoria.Nombre;
            categoriaExistente.Habilitado = categoria.Habilitado;

            _context.SaveChanges();

            return NoContent();
        }


        // DELETE: api/CategoriaCurso/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria(int id)
        {
            var categoria = _context.CategoriaCursos.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.CategoriaCursos.Remove(categoria);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
