using Microsoft.EntityFrameworkCore;

namespace APILibros.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) 
        { }

        public DbSet<Libro> libros { get; set; }
        public DbSet<Autor> autores { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Residencia> Residencias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .HasMany(a => a.Libros) // Autor tiene muchos Libros
                .WithOne(l => l.Autor)  // Cada Libro pertenece a un Autor
                .HasForeignKey(l => l.AutorId); // La clave foránea en Libro que apunta a Autor

            // Configuración de la llave compuesta para Departamento
            modelBuilder.Entity<Departamento>()
                .HasKey(d => new { d.CodigoPais, d.CodigoDepartamento });

            // Configuración de la llave compuesta para Municipio
            modelBuilder.Entity<Municipio>()
                .HasKey(m => new { m.CodigoPais, m.CodigoDepartamento, m.CodigoMunicipio });

            // Asegurarse que las relaciones de navegación están correctamente configuradas
            modelBuilder.Entity<Departamento>()
                .HasOne(d => d.Pais)
                .WithMany(p => p.Departamentos) //Departamentos es la lista que esta en pais
                .HasForeignKey(d => d.CodigoPais);

            modelBuilder.Entity<Municipio>()
                .HasOne(m => m.Departamento)
                .WithMany(d => d.Municipios)
                .HasForeignKey(m => new { m.CodigoPais, m.CodigoDepartamento });

            modelBuilder.Entity<Residencia>()
                 .HasOne(m => m.Municipio)
                 .WithMany(d => d.Residencias)
                 .HasForeignKey(m => new { m.CodigoPais, m.CodigoDepartamento, m.CodigoMunicipio });

            // Definición de la restricción única para Residencia
            modelBuilder.Entity<Residencia>()
                .HasIndex(r => new { r.Direccion, r.CodigoPais, r.CodigoDepartamento, r.CodigoMunicipio })
                .IsUnique();
        }
    }
}
