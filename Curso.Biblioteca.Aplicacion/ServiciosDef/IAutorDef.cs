using Curso.Biblioteca.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServiciosDef
{
    public interface IAutorDef
    {
        /// <summary>
        /// Obtenemos todos los autores
        /// </summary>
        Task<ICollection<AutorDto>> GetAllAsync();

        /// <summary>
        /// Obtener autor por id
        /// </summary>
        Task<AutorDto> GetByIdAsync(int id);

        /// <summary>
        ///Crear autor
        ///Forma asíncrona
        /// </summary>
        Task<bool> CreateAsync(CrearAutorDto entity);

        /// <summary>
        /// Actualizar autor.
        /// Forma asincrona
        /// </summary>
        Task<bool> UpdateAsync(int id, CrearAutorDto entityDto);

        /// <summary>
        /// Eliminar autor
        /// Forma asincrona
        /// </summary>
        Task<bool> DeleteAsync(int id);
       
    }
}
