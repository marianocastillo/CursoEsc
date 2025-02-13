using System;
using System.Collections.Generic;

namespace CursoAPI.Models;

public partial class CategoriaCurso
{
    public int Iidcategoriacurso { get; set; }

    public string? Nombre { get; set; }

    public int? Habilitado { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
