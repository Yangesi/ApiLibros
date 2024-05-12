using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILibros.Models
{
    public class Libro
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibroId { get; set; }

        public string LibroName { get; set; }
        public string LibroDescription { get; set; }

        public string Direccion { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Precision(18, 2)]
        public decimal Precio { get; set; } = 0.00m;

        // Clave foránea de Autor
        public int AutorId { get; set; }
        // Propiedad de navegación para Autor
        public Autor Autor { get; set; }

    }
}
