using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILibros.Models
{
    public class Departamento
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Asumiendo que quieres especificar estos valores manualmente
        public int CodigoPais { get; set; } // Parte de la llave compuesta

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoDepartamento { get; set; } // Parte de la llave compuesta y clave primaria

        [ForeignKey("CodigoPais")]
        public Pais Pais { get; set; } // Propiedad de navegación a País

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        // Propiedad de navegación para Municipios
        public List<Municipio> Municipios { get; set; } = new List<Municipio>();
    }
}

