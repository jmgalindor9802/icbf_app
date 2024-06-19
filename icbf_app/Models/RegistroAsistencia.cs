using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_app.Models;

public partial class RegistroAsistencia
{

    public int IdRegistroAsistencia { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Niño")]
    public long IdNino { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Fecha de nacimiento")]
    public DateOnly FechaRegistro { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Estado")]
    public string EstadoNinoRegistro { get; set; } = null!;
    public virtual Nino IdNinoNavigation { get; set; } = null!;
}
