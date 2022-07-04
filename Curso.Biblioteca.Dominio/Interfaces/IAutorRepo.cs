using Curso.Biblioteca.Dominio.Entidades;

namespace Curso.Biblioteca.Dominio.Interfaces
{
    public interface IAutorRepo
    {
        IQueryable<Autor> GetAllAsync();
        IQueryable<Autor> GetAll();
        Task CreateAsync(Autor autor);
        Task UpdateAsync(Autor autor);
        Task DeleteAsync(Autor autor);

    }
}
