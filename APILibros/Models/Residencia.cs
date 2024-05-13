using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APILibros.Models
{
    public class Residencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; } // Clave primaria autoincremental

        [Required]
        public int CodigoPais { get; set; } // Código del país

        [Required]
        public int CodigoDepartamento { get; set; } // Código del departamento

        [Required]
        public int CodigoMunicipio { get; set; } // Código del municipio

        [ForeignKey("CodigoPais, CodigoDepartamento, CodigoMunicipio")]
        public Municipio Municipio { get; set; } // Propiedad de navegación a Municipio

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; } // Dirección

        [Required]
        [StringLength(100)]
        public string Referencia { get; set; } // Referencia

    }
}
