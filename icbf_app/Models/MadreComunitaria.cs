using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_app.Models;

public partial class MadreComunitaria
{
    public int IdMadreComunitaria { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]

    public DateOnly FechaNacimientoMadre { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public int IdJardin { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public string IdUsuario { get; set; } = null!;

    public virtual Jardin IdJardinNavigation { get; set; } = null!;

    public virtual AspNetUser IdUsuarioNavigation { get; set; } = null!;
}
