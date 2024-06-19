using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_app.Models;

public partial class RegistroAvanceAcademico
{
    public int IdAvance { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Niño")]
    public long IdNino { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Año escolar")]
    public int AnioEscolarAvance { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Nivel de avance")]
    public string NivelAvance { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Nota avance")]
    public string NotaAvance { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio")]
    [MaxLength(5000, ErrorMessage = "La descripcion debe tener maximo 5000 caracteres")]
    [MinLength(10, ErrorMessage = "La descripcion debe tener minimo 10 caracteres")]
    [Display(Name = "Descripcion")]
    public string DescripcionAvance { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Fecha de entrega")]
    public DateOnly FechaEntregaAvance { get; set; }
    public virtual Nino IdNinoNavigation { get; set; } = null!;
}
