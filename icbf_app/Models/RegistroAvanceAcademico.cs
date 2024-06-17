using System;
using System.Collections.Generic;

namespace icbf_app.Models;

public partial class RegistroAvanceAcademico
{
    public int IdAvance { get; set; }

    public long IdNino { get; set; }

    public int AnioEscolarAvance { get; set; }

    public string NivelAvance { get; set; } = null!;

    public string NotaAvance { get; set; } = null!;

    public string DescripcionAvance { get; set; } = null!;

    public DateOnly FechaEntregaAvance { get; set; }

    public virtual Nino IdNinoNavigation { get; set; } = null!;
}
