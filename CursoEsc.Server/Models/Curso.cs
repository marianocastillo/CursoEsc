using System;
using System.Collections.Generic;

namespace CursoAPI.Models;

public partial class Curso
{
    public int Iidcurso { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }


    public int? Iidcategoriacurso { get; set; }

    public decimal Precio { get; set; }

    public string? Cupon { get; set; }

    public int? Bhabilitado { get; set; }

    public string? Imagen { get; set; }

    public virtual CategoriaCurso? IidcategoriacursoNavigation { get; set; }

    public virtual ICollection<SeccionCurso> SeccionCursos { get; set; } = new List<SeccionCurso>();
}
