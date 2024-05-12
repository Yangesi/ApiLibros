using System.ComponentModel.DataAnnotations;

namespace APILibros.Models
{
    public class Autor
    {

        [Key]
        public int AutorId { get; set; } // Primary Key

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Nacionalidad { get; set; }

        // Propiedad de navegación para libros
        public List<Libro> Libros { get; set; } = new List<Libro>();

    }
}
