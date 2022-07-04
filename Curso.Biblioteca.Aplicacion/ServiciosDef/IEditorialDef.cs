using Curso.Biblioteca.Aplicacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServiciosDef
{
    public interface IEditorialDef
    {
        /// <summary>
        /// Obtener todas las editoriales
        /// </summary>
        Task<ICollection<EditorialDto>> GetAllAsync();

        /// <summary>
        /// Obtener editorial por id
        /// </summary>
        Task<EditorialDto> GetByIdAsync(int id);

        /// <summary>
        ///Crear editoriales
        /// </summary>
        Task<bool> CreateAsync(CrearEditorial editorial);

        /// <summary>
        ///Actualiza editoriales
        /// </summary>
        Task<bool> UpdateAsync(int id, CrearEditorial editorialDto);

        /// <summary>
        ///eliminar por id
        /// </summary>
        Task<bool> DeleteAsync(int id);
    }
}
