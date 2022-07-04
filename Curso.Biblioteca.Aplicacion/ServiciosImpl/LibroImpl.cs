using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServiciosDef;
using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServiciosImpl
{
    public class LibroImpl : ILibroDef
    { 
     private readonly ILibroRepo libroRep;

    public LibroImpl(ILibroRepo libroRep)
    {
        this.libroRep = libroRep;
    }

    public async Task<bool> CreateAsync(CrearLibro libroDto)
    {
        var libro = new Libro
        {
            Titulo = libroDto.Titulo,
            ISBN = libroDto.ISBN,
            AutorId = libroDto.AutorId,
            EditorialId = libroDto.EditorialId
        };
        await libroRep.CreateAsync(libro);

        return true;
    }

        public async Task<bool> UpdateAsync(int id, CrearLibro libroDto)
        {
            var consulta = libroRep.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var libro = consulta.SingleOrDefault();

            libro.Titulo = libroDto.Titulo;
            libro.ISBN = libroDto.ISBN;
            libro.AutorId = libroDto.AutorId;
            libro.EditorialId = libroDto.EditorialId;

            await libroRep.UpdateAsync(libro);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
    {
        var consulta = libroRep.GetAll();
        consulta = consulta.Where(c => c.Id == id);
        var libro = consulta.SingleOrDefault();

        await libroRep.DeleteAsync(libro);
        return true;
    }

    public async Task<ICollection<LibroDto>> GetAllAsync()
    {
        var query = libroRep.GetAll();
        var listaLibros = await query.Select(c => new LibroDto
        {
            Id = c.Id,
            Titulo = c.Titulo,
            ISBN = c.ISBN,
            Autor = $" {c.Autor.Apellido} {c.Autor.Nombre}",
            Editorial = c.Editorial.Nombre
        }).ToListAsync();

        return listaLibros;
    }

    public async Task<LibroDto> GetByIdAsync(int id)
    {
        var query = libroRep.GetAll();
        query = query.Where(c => c.Id == id);
        var libro = await query.Select(c => new LibroDto
        {
            Id = c.Id,
            Titulo = c.Titulo,
            ISBN = c.ISBN,
            Autor = $"{c.Autor.Apellido} {c.Autor.Nombre}",
            Editorial = c.Editorial.Nombre
        }).SingleOrDefaultAsync();

        return libro;
    }

    
}
}