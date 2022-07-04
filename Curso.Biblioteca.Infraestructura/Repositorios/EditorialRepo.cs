using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Repositorios
{
    public class EditorialRepo : IEditorialRepo
    {
        private readonly BibliotecaDbContext context;
        public EditorialRepo(BibliotecaDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Editorial entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Editorial entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
        //este IQueryable es para consultar todos lo registros 
        public IQueryable<Editorial> GetAll()
        {
            return context.Editorial.AsQueryable();
        }

        public async Task UpdateAsync(Editorial entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
