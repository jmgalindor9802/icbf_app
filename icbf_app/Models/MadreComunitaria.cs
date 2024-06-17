using System;
using System.Collections.Generic;

namespace icbf_app.Models;

public partial class MadreComunitaria
{
    public int IdMadreComunitaria { get; set; }

    public DateOnly FechaNacimientoMadre { get; set; }

    public int IdJardin { get; set; }

    public string IdUsuario { get; set; } = null!;

    public virtual Jardin IdJardinNavigation { get; set; } = null!;

    public virtual AspNetUser IdUsuarioNavigation { get; set; } = null!;
}
