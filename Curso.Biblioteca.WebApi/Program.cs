using Curso.Biblioteca.Aplicacion.ServiciosDef;
using Curso.Biblioteca.Aplicacion.ServiciosImpl;
using Curso.Biblioteca.Infraestructura;
using Curso.Biblioteca.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Curso.Biblioteca.Dominio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddDbContext<BibliotecaDbContext>();
builder.Services.AddTransient<IAutorRepo, AutorRepo>();
builder.Services.AddTransient<IAutorDef, AutorImpl>();

builder.Services.AddTransient<IEditorialRepo, EditorialRepo>();
builder.Services.AddTransient<IEditorialDef, EditorialImpl>();

builder.Services.AddTransient<ILibroRepo,LibroRepo>();
builder.Services.AddTransient<ILibroDef, LibroImpl>();
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
