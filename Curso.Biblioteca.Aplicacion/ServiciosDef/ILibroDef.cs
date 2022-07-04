using Curso.Biblioteca.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServiciosDef
{
    public interface ILibroDef
    {
        /// <summary>
        /// obtener todos los libros
        /// </summary>
        Task<ICollection<LibroDto>> GetAllAsync();

        /// <summary>
        /// obtiene libros por id
        /// </summary>
        Task<LibroDto> GetByIdAsync(int id);

        /// <summary>
        /// crea un libro
        /// </summary>
        Task<bool> CreateAsync(CrearLibro libro);

        /// <summary>
        /// actualiza un l ibro
        /// </summary>
        Task<bool> UpdateAsync(int id, CrearLibro libroDto);

        /// <summary>
        /// elimina por id me retorna unn booleano
        /// </summary>
        Task<bool> DeleteAsync(int id);
    }
}
