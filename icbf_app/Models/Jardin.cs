using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_app.Models;

public partial class Jardin
{
    public int IdJardin { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(100, ErrorMessage = "El nombre del jardin como maximo debetener 100 caracteres")]
    [MinLength(8, ErrorMessage = "El nombre del jardin como minimo debe tener 8 caracteres")]
    public string NombreJardin { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    [MaxLength(200, ErrorMessage = "La direccion del jardin como maximo debetener 200 caracteres")]
    [MinLength(8, ErrorMessage = "La direccion del jardin como minimo debe tener 8 caracteres")]
    public string DireccionJardin { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    public string EstadoJardin { get; set; } = null!;

    public virtual ICollection<MadreComunitaria> MadresComunitaria { get; set; } = new List<MadreComunitaria>();

    public virtual ICollection<Nino> Ninos { get; set; } = new List<Nino>();
}
