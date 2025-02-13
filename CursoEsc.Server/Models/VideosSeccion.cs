using System;
using System.Collections.Generic;

namespace CursoAPI.Models;

public partial class VideosSeccion
{
    public int Iidvideos { get; set; }

    public string? Nombre { get; set; }

    public string? Video { get; set; }

    public string? Enlace { get; set; }

    public int? Bhabilitado { get; set; }

    public int? Iidseccion { get; set; }

    public virtual SeccionCurso? IidseccionNavigation { get; set; }
}
