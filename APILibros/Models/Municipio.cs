using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILibros.Models
{
    public class Municipio
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoPais { get; set; } // Parte de la llave compuesta

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodigoDepartamento { get; set; } // Parte de la llave compuesta

        [Key, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoMunicipio { get; set; } // Parte de la llave compuesta y clave primaria

        [ForeignKey("CodigoPais, CodigoDepartamento")]
        public Departamento Departamento { get; set; } // Propiedad de navegación a Departamento

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        // Propiedad de navegación para Residencias
        public List<Residencia> Residencias { get; set; } = new List<Residencia>();

    }
}

