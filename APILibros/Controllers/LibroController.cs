using APILibros.DTOs;
using APILibros.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private IValidator<LibroInsertDto> _libroInsertValidator;
        private IValidator<LibroUpdateDto> _libroUpdateValidator;
        private ICommonService<LibroDto, LibroInsertDto, LibroUpdateDto> _libroService;
        private readonly PdfService _pdfService;
        public LibroController(IValidator<LibroInsertDto> libroInsertValidator,
            IValidator<LibroUpdateDto> libroUpdateValidator,
            [FromKeyedServices("LibroService")]ICommonService<LibroDto, LibroInsertDto, LibroUpdateDto> libroService, PdfService pdfService) 
        {
            _libroService = libroService;
            _libroInsertValidator = libroInsertValidator;
            _libroUpdateValidator = libroUpdateValidator;
            _pdfService = pdfService;
        }

        [HttpGet]
        public async Task<IEnumerable<LibroDto>> Get() =>
            await _libroService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroDto>> GetById(int id)
        {
            var libroDto = await _libroService.GetById(id);

            return libroDto == null ? NotFound() : Ok(libroDto);
        }

        [HttpPost]
        public async Task<ActionResult<LibroDto>> add(LibroInsertDto libroInsertDto)
        {

            var validationResult = await _libroInsertValidator.ValidateAsync(libroInsertDto);
          
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (!_libroService.Validate(libroInsertDto))
            {
                return BadRequest(_libroService.Errors);
            }

            var libroDto = await _libroService.Add(libroInsertDto);
            return CreatedAtAction(nameof(GetById), new { id = libroDto.LibroId }, libroDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LibroDto>> update(int id, LibroUpdateDto libroUpdateDto)
        {
            var validationResult = await _libroUpdateValidator.ValidateAsync(libroUpdateDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (!_libroService.Validate(libroUpdateDto))
            {
                return BadRequest(_libroService.Errors);
            }

            var libroDto = await _libroService.Update(id, libroUpdateDto);

            return libroDto == null ? NotFound() : Ok(libroDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LibroDto>> Delete(int id)
        {
            var libroDto = await _libroService.Delete(id);

            return libroDto == null ? NotFound() : Ok(libroDto);
        }

        // Método para descargar el PDF
        [HttpGet("download-pdf")]
        public async Task<IActionResult> DownloadPdf()
        {
            try
            {
                // Genera el PDF y recibe los bytes
                byte[] pdfBytes = await _pdfService.CreatePdf();

                // Retorna el archivo PDF como respuesta
                return File(pdfBytes, "application/pdf", "Listado_de_Libros.pdf");
            }
            catch (Exception ex)
            {
                // Manejo de errores: Retorna un código de estado 500 con el mensaje de error
                return StatusCode(500, ex.Message);
            }
        }
        //fin del metodo descargar pdf

    }
}
