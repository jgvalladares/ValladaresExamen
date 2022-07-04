using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Repositorios
{
    public class LibroRepo : ILibroRepo
    {
        private readonly BibliotecaDbContext context;
        public LibroRepo(BibliotecaDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Libro entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Libro entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
        //este IQueryable es para consultar todos lo registros 
        public IQueryable<Libro> GetAll()
        {
            return context.Libro.AsQueryable();
        }

        public async Task UpdateAsync(Libro entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
