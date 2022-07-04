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
    public class EditorialImpl:IEditorialDef
    {
        private readonly IEditorialRepo editorialRepositorio;

        public EditorialImpl(IEditorialRepo editorialRep)
        {
            this.editorialRepositorio = editorialRepositorio;
        }
        /// <summary>
        /// ////////////// crear una editorial
        /// </summary>
        /// <param name="editorialDto"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(CrearEditorial editorialDto)
        {
            var editorial = new Editorial
            {
                Nombre = editorialDto.Nombre,
                Direccion = editorialDto.Direccion
            };
            await editorialRepositorio.CreateAsync(editorial);

            return true;
        }
        /// <summary>
        /// editar na editorial
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(int id, CrearEditorial editorialDto)
        {

            var query = editorialRepositorio.GetAll();
            //comparamos la id ue ingresamos con la de la base de datos para que se edite
            query = query.Where(c => c.Id == id);
            var result = query.SingleOrDefault();

            result.Nombre = editorialDto.Nombre;
            result.Direccion = editorialDto.Direccion;

            await editorialRepositorio.UpdateAsync(result);
            return true;
        }

        /// <summary>
        /// elimianr editoriales
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            //// se debe realizar una consulta por id para eliminar de manera lógica
            var query = editorialRepositorio.GetAll();
            query = query.Where(c => c.Id == id);
            var editorial = query.SingleOrDefault();
            //me devuelve solo ese registro

            await editorialRepositorio.DeleteAsync(editorial);
            return true;
        }
        /// <summary>
        /// /////obtenemos todo
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            //obtenemos todas las editoriales de anera asincrona utilzando linq 
            var query = editorialRepositorio.GetAll();
            var result= await query.Select(c => new EditorialDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Direccion = c.Direccion
            }).ToListAsync();

            return result;
        }
        /// <summary>
        /// //obtenemos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EditorialDto> GetByIdAsync(int id)
        {
            var query = editorialRepositorio.GetAll();
            query = query.Where(c => c.Id == id);
            var result = await query.Select(x => new EditorialDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Direccion = x.Direccion
            }).SingleOrDefaultAsync();

            return result;
        }

       
    }
}