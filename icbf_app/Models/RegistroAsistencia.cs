using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_app.Models;

public partial class RegistroAsistencia
{

    public int IdRegistroAsistencia { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public long IdNino { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public DateOnly FechaRegistro { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    public string EstadoNinoRegistro { get; set; } = null!;
    public virtual Nino IdNinoNavigation { get; set; } = null!;
}
