using APILibros.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using APILibros.Services; // Asegúrate de tener tus interfaces y DTOs importados correctamente.
using QuestPDF.Helpers;

namespace APILibros.Services
{
    public class PdfService
    {
        private readonly ICommonService<LibroDto, LibroInsertDto, LibroUpdateDto> _libroService;

        public PdfService([FromKeyedServices("LibroService")] ICommonService<LibroDto, LibroInsertDto, LibroUpdateDto> libroService)
        {
            _libroService = libroService;
        }

        public async Task<byte[]> CreatePdf()
        {
            var libros = await _libroService.Get();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));
                    page.Header().Element(ComposeHeader);
                    page.Content()
                        .Column(column =>
                        {
                            foreach (var libro in libros)
                            {
                                column.Item().PaddingVertical(5).Row(row =>
                                {
                                    row.ConstantItem(50).Text($"ID: {libro.LibroId}");
                                    row.RelativeItem().Text(libro.LibroName).Bold();
                                });
                                column.Item().Text(libro.LibroDescription);
                            }
                        });
                    page.Footer().AlignCenter().Text(x => x.CurrentPageNumber());
                });
            });

            using var stream = new MemoryStream();
            document.GeneratePdf(stream);
            return stream.ToArray();
        }


        private void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Text("Listado de Libros").FontSize(20).Bold();
            });
        }

        private void ComposeContent(IContainer container, IEnumerable<LibroDto> libros)
        {
            container.Column(column =>
            {
                foreach (var libro in libros)
                {
                    column.Item().PaddingVertical(5).Row(row =>
                    {
                        row.ConstantItem(50).Text($"ID: {libro.LibroId}");
                        row.RelativeItem().Text(libro.LibroName).Bold();
                    });
                    column.Item().Text(libro.LibroDescription);
                }
            });
        }
    }

}
