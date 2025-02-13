//using CursoAPI.Models;
//using CursoAPI.ViewsModel;
//using Microsoft.AspNetCore.Mvc;

//namespace CursoAPI.Controllers
//{
//    public class SeccionController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public IActionResult create(ViewsSeccion _seccion)
//        {
//            using (var db = new BdcursoContext())
//            {

//                Curso guardar = new Curso()
//                {
//                    Iidcurso = _seccion.Iidseccion


//                };
//                db.Cursos.Add(guardar);
//                db.SaveChanges();


//            }


//            return View();
//        }



//    }
//}


using Microsoft.AspNetCore.Mvc;
using CursoAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CursoEsc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionCursoController : ControllerBase
    {
        private readonly BdcursoContext _context;

        public SeccionCursoController(BdcursoContext context)
        {
            _context = context;
        }

        // GET: api/SeccionCurso
        [HttpGet]
        public ActionResult<IEnumerable<SeccionCurso>> GetSeccionCursos()
        {
            return _context.SeccionCursos.ToList();
        }

        // GET: api/SeccionCurso/5
        [HttpGet("{id}")]
        public ActionResult<SeccionCurso> GetSeccionCurso(int id)
        {
            var seccionCurso = _context.SeccionCursos.Find(id);

            if (seccionCurso == null)
            {
                return NotFound();
            }

            return seccionCurso;
        }

        // POST: api/SeccionCurso
        [HttpPost]
        public ActionResult<SeccionCurso> PostSeccionCurso(SeccionCurso seccionCurso)
        {
            _context.SeccionCursos.Add(seccionCurso);
            _context.SaveChanges();

            return CreatedAtAction("GetSeccionCurso", new { id = seccionCurso.Iidseccion }, seccionCurso);
        }

        // PUT: api/SeccionCurso/5
        [HttpPut("{id}")]
        public IActionResult PutSeccionCurso(int id, SeccionCurso seccionCurso)
        {
            if (id != seccionCurso.Iidseccion)
            {
                return BadRequest();
            }

            _context.Entry(seccionCurso).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeccionCursoExists(id))
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

        // DELETE: api/SeccionCurso/5
        [HttpDelete("{id}")]
        public ActionResult<SeccionCurso> DeleteSeccionCurso(int id)
        {
            var seccionCurso = _context.SeccionCursos.Find(id);
            if (seccionCurso == null)
            {
                return NotFound();
            }

            _context.SeccionCursos.Remove(seccionCurso);
            _context.SaveChanges();

            return seccionCurso;
        }

        private bool SeccionCursoExists(int id)
        {
            return _context.SeccionCursos.Any(e => e.Iidseccion == id);
        }
    }
}
