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
    public class AutorImpl:IAutorDef
    {
        private readonly IAutorRepo autorRep;

        public AutorImpl(IAutorRepo autorRep)
        {
            this.autorRep = autorRep;
        }

        public async Task<bool> CreateAsync(CrearAutorDto autorDto)
        {
            var autor = new Autor
            {
                Nombre = autorDto.Nombre,
                Apellido = autorDto.Apellido
            };
            await autorRep.CreateAsync(autor);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var consulta = autorRep.GetAll();
            consulta = consulta.Where(c => c.Id == id);
            var autor = consulta.SingleOrDefault();

            await autorRep.DeleteAsync(autor);
            return true;
        }

        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            var consulta = autorRep.GetAll();
            var listaAutores = await consulta.Select(x => new AutorDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).ToListAsync();

            return listaAutores;
        }

        public async Task<AutorDto> GetByIdAsync(int id)
        {
            var query = autorRep.GetAll();
            query = query.Where(c => c.Id == id);
            var result = await query.Select(x => new AutorDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).SingleOrDefaultAsync();

            return result;
        }

        public async Task<bool> UpdateAsync(int id, CrearAutorDto autorDto)
        {
            var query = autorRep.GetAll();
            query = query.Where(c => c.Id == id);
            var result = query.SingleOrDefault();

            result.Nombre = autorDto.Nombre;
            result.Apellido = autorDto.Apellido;

            await autorRep.UpdateAsync(result);
            return true;
        }
    }
}