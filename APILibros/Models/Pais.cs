using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILibros.Models
{
    public class Pais
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoPais { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        // Propiedad de navegación para Departamentos
        public List<Departamento> Departamentos { get; set; } = new List<Departamento>();
    }
}
