using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Repositorios
{
    public class AutorRepo : IAutorRepo
    {
        private readonly BibliotecaDbContext context;
        public AutorRepo(BibliotecaDbContext context)
        {
            this.context = context;
        }
        
        public async Task CreateAsync(Autor entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(Autor entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
        //este IQueryable es para consultar todos lo registros 
        public IQueryable<Autor> GetAll()
        {
        return context.Autor.AsQueryable();
        }

        public IQueryable<Autor> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Autor entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
        
    }
}
