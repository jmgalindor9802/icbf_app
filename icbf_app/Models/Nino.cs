using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace icbf_app.Models;

public partial class Nino
{
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Nuip")]
    public long IdNino { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    [MaxLength(10, ErrorMessage = "El nombre del niño debe tener maximo 10 caracteres")]
    [MinLength(5, ErrorMessage = "El nombre del niño debe tener minimo 5 caracteres")]
    [Display(Name = "Nombre")]
    public string NombreNino { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Fecha nacimiento")]
    public DateOnly FechaNacimientoNino { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Tipo de sangre")]
    public string TipoSangreNino { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio")]
    [MaxLength(50, ErrorMessage = "La cuidad de nacimiento del niño debe tener maximo 50 caracteres")]
    [MinLength(6, ErrorMessage = "La cuidad de nacimiento del niño debe tener minimo 6 caracteres")]
    [Display(Name = "Ciudad de nacimiento")]
    public string CiudadNacimientoNino { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Acudiente")]
    public string IdAcudiente { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio")]
    [MaxLength(10, ErrorMessage = "El telefono debe tener maximo 10 caracteres")]
    [MinLength(10, ErrorMessage = "El telefono debe tener minimo 10 caracteres")]
    [Display(Name = "Telefono")]
    public string TelefonoNino { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio")]
    [MaxLength(50, ErrorMessage = "La direccion del niño debe tener maximo 50 caracteres")]
    [MinLength(5, ErrorMessage = "La direccion del niño debe tener minimo 5 caracteres")]
    [Display(Name = "Direccion de recidencia")]
    public string DireccionNino { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio")]
    [MaxLength(50, ErrorMessage = "La EPS del niño debe tener maximo 50 caracteres")]
    [MinLength(5, ErrorMessage = "La EPS del niño debe tener minimo 5 caracteres")]
    [Display(Name = "EPS")]
    public string EpsNino { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Display(Name = "Jardin")]
    public int IdJardin { get; set; }

    public virtual AspNetUser IdAcudienteNavigation { get; set; } = null!;

    public virtual Jardin IdJardinNavigation { get; set; } = null!;

    public virtual ICollection<RegistroAsistencia> RegistrosAsistencia { get; set; } = new List<RegistroAsistencia>();

    public virtual ICollection<RegistroAvanceAcademico> RegistrosAvanceAcademicos { get; set; } = new List<RegistroAvanceAcademico>();
}
