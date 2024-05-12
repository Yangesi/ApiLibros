using APILibros.DTOs;
using APILibros.Models;
using APILibros.Repository;
using APILibros.Services;
using APILibros.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//inyeccion del servicio de libro
builder.Services.AddKeyedScoped<ICommonService<LibroDto, LibroInsertDto, LibroUpdateDto>, LibroService>("LibroService");

//repository service
builder.Services.AddScoped<IRepository<Libro>, LibroRepository>();

//validadores
builder.Services.AddScoped<IValidator<LibroInsertDto>, LibroInsertValidator>();
builder.Services.AddScoped<IValidator<LibroUpdateDto>, LibroUpdateValidator>();

//servicio pdf
builder.Services.AddScoped<PdfService>();
QuestPDF.Settings.License = LicenseType.Community;


//contexto a base de datos, servicio
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
