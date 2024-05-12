using APILibros.DTOs;
using APILibros.Models;
using APILibros.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APILibros.Services
{
    public class LibroService : ICommonService<LibroDto, LibroInsertDto, LibroUpdateDto>
    {
        private IRepository<Libro> _libroRepository;

        public List<string> Errors { get; }
        public LibroService(IRepository<Libro> libroRepository) 
        {
            _libroRepository = libroRepository;
            Errors = new List<string>();
        }
        public async Task<IEnumerable<LibroDto>> Get()
        {
            var libros = await _libroRepository.Get();

            return libros.Select(l => new LibroDto()
            {
                LibroId = l.LibroId,
                LibroName = l.LibroName,
                LibroDescription = l.LibroDescription,
            });
        }
        public async Task<LibroDto> GetById(int id)
        {
            var libro = await _libroRepository.GetById(id);

            if(libro != null)
            {
                var libroDto = new LibroDto
                {
                    LibroId = libro.LibroId,
                    LibroName = libro.LibroName,
                    LibroDescription = libro.LibroDescription
                };

                return libroDto;
             
            }

            return null;
        }

        public async Task<LibroDto> Add(LibroInsertDto libroInsertDto)
        {
            var libro = new Libro()
            {
                LibroName = libroInsertDto.LibroName,
                LibroDescription = libroInsertDto.LibroDescription
            };

            await _libroRepository.Add(libro);
            await _libroRepository.Save();

            var libroDto = new LibroDto
            {
                LibroId = libro.LibroId,
                LibroName = libro.LibroName,
                LibroDescription = libro.LibroDescription
            };

            return libroDto;
        }

        public async Task<LibroDto> Update(int id, LibroUpdateDto libroUpdateDto)
        {
            var libro = await _libroRepository.GetById(id);

            if (libro != null)
            {
                libro.LibroName = libroUpdateDto.LibroName;
                libro.LibroDescription = libroUpdateDto.LibroDescription;

                _libroRepository.Update(libro);
                await _libroRepository.Save();

                var libroDto = new LibroDto
                {
                    LibroId = libro.LibroId,
                    LibroDescription = libro.LibroDescription
                };

                return libroDto;
            }

            return null;
        }
        public async Task<LibroDto> Delete(int id)
        {
            var libro = await _libroRepository.GetById(id);

            if (libro != null)
            {
                var libroDto = new LibroDto
                {
                    LibroId = libro.LibroId,
                    LibroDescription = libro.LibroDescription
                };

                _libroRepository.Delete(libro);
                await _libroRepository.Save();

                return libroDto;
            }

            return null;

        }

        public bool Validate(LibroInsertDto libroInsertDto)
        {
            if (_libroRepository.Search(b => b.LibroName == libroInsertDto.LibroName).Count() > 0)
            {
                Errors.Add("No puede existir otro libro igual");
                return false;
            }
            return true;
        }

        public bool Validate(LibroUpdateDto libroUpdateDto)
        {//falta agregar validacion del id de libro porque no esta en updatedto
            if (_libroRepository.Search(b => b.LibroName == libroUpdateDto.LibroName 
            && libroUpdateDto.LibroId != b.LibroId).Count() > 0)
            {
                Errors.Add("No puede existir otro libro igual");
                return false;
            }
            return true;
        }
    }
}
