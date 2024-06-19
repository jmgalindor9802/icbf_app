using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_app.Models;

public partial class MadreComunitaria
{
    public int IdMadreComunitaria { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [DataType(DataType.Date)]
    //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    [Display(Name = "Fecha de nacimiento")]
    public DateOnly FechaNacimientoMadre { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Jardin")]
    public int IdJardin { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [Display(Name = "Usuario")]
    public string IdUsuario { get; set; } = null!;

    public virtual Jardin IdJardinNavigation { get; set; } = null!;

    public virtual AspNetUser IdUsuarioNavigation { get; set; } = null!;
}
