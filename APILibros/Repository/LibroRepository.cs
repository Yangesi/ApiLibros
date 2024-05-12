using APILibros.Models;
using Microsoft.EntityFrameworkCore;

namespace APILibros.Repository
{
    public class LibroRepository : IRepository<Libro>
    {
        private StoreContext _context;

        public LibroRepository(StoreContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Libro>> Get() =>
            await _context.libros.ToListAsync();


        public async Task<Libro> GetById(int id) =>
            await _context.libros.FindAsync(id);

        public async Task Add(Libro entity) =>
            await _context.libros.AddAsync(entity);

        public void Update(Libro entity)
        {
            _context.libros.Attach(entity);
            _context.libros.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Libro entity) =>
            _context.libros.Remove(entity);

        public async Task Save() =>
            await _context.SaveChangesAsync(); 

        public IEnumerable<Libro> Search(Func<Libro, bool> filter) =>
            _context.libros.Where(filter).ToList();
    }
}
