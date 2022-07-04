using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServiciosDef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase, IAutorDef
    {
        private readonly IAutorDef autorServicio;

        public AutorController(IAutorDef autorServicio)
        {
            this.autorServicio = autorServicio;
        }

        [HttpGet]
        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            return await autorServicio.GetAllAsync();
        }
       

        [HttpGet("{id}")]
        public async Task<AutorDto> GetByIdAsync(int id)
        {
            return await autorServicio.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateAsync(CrearAutorDto crearAutorDto)
        {
            return await autorServicio.CreateAsync(crearAutorDto);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateAsync(int id, CrearAutorDto autorDto)
        {
            return await autorServicio.UpdateAsync(id, autorDto);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await autorServicio.DeleteAsync(id);
        }
    }
}