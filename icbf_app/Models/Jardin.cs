using System;
using System.Collections.Generic;

namespace icbf_app.Models;

public partial class Jardin
{
    public int IdJardin { get; set; }

    public string NombreJardin { get; set; } = null!;

    public string DireccionJardin { get; set; } = null!;

    public string EstadoJardin { get; set; } = null!;

    public virtual ICollection<MadreComunitaria> MadresComunitaria { get; set; } = new List<MadreComunitaria>();

    public virtual ICollection<Nino> Ninos { get; set; } = new List<Nino>();
}
