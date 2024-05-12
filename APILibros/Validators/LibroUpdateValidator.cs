using APILibros.DTOs;
using FluentValidation;

namespace APILibros.Validators
{
    public class LibroUpdateValidator : AbstractValidator<LibroUpdateDto>
    {
        public LibroUpdateValidator() 
        {
            RuleFor(x => x.LibroName).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.LibroName).Length(2, 20).WithMessage("2-20 caracteres");
        }
    }
}
