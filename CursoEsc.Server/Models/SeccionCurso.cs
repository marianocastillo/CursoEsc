using System;
using System.Collections.Generic;

namespace CursoAPI.Models;

public partial class SeccionCurso
{
    public int Iidseccion { get; set; }
    
    public string? Nombreseccion { get; set; }

    public int? Iidcurso { get; set; }

    public string? Descripcionseccion { get; set; }

    public int? Bhabilitado { get; set; }

    public virtual Curso? IidcursoNavigation { get; set; }

    public virtual ICollection<VideosSeccion> VideosSeccions { get; set; } = new List<VideosSeccion>();
}
