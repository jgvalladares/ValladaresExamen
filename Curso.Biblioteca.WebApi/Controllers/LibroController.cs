using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServiciosDef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase, ILibroDef
    {
        private readonly ILibroDef libroDef;

        public LibroController(ILibroDef libroDef)
        {
            this.libroDef = libroDef;
        }

        [HttpGet]
        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            return await libroDef.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<LibroDto> GetByIdAsync(int id)
        {
            return await libroDef.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateAsync(CrearLibro crearLibroDto)
        {
            return await libroDef.CreateAsync(crearLibroDto);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateAsync(int id, CrearLibro libroDto)
        {
            return await libroDef.UpdateAsync(id, libroDto);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await libroDef.DeleteAsync(id);
        }
    }
}
