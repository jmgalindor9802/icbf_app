using System;
using System.Collections.Generic;

namespace icbf_app.Models;

public partial class RegistroAsistencia
{
    public int IdRegistroAsistencia { get; set; }

    public long IdNino { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public string EstadoNinoRegistro { get; set; } = null!;

    public virtual Nino IdNinoNavigation { get; set; } = null!;
}
