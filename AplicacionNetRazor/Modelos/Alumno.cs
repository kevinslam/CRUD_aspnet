using System.ComponentModel.DataAnnotations;

namespace AplicacionNetRazor.Modelos
{
    public class Alumno
    {
        [Key]
        [Display(Name = "Clave")]
        public int IdAlumno { get; set; }
        [StringLength(100)]
        [Required]
        public string Nombre { get; set; }
        [StringLength(50)]
        [Required]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Fecha de ingreso")]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime Fecha_ing { get; set; }
        [Required]
        [Display(Name = "Hora de ingreso")]
        [DisplayFormat(DataFormatString = "{0: hh:mm:ss}")]
        public DateTime Hora_ing { get; set; }
        [Required]
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime Fecha_nac { get; set; }
        [Required]
        [Display(Name = "Cantidad de cursos")]
        public int Cant_cursos { get; set; }
        [Display(Name = "Fecha de egreso")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime Fecha_egr { get; set; }

    }
}
