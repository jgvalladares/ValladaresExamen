using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Dominio.Interfaces
{
    public interface IEditorialRepo
    {
         IQueryable<Editorial> GetAll();
        Task CreateAsync(Editorial editorial);
        Task UpdateAsync(Editorial editorial);
        Task DeleteAsync(Editorial editorial);
    }
}
