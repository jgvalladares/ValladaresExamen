using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.ServiciosDef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase, IEditorialDef
    {
        private readonly IEditorialDef editorialServicio;

        public EditorialController(IEditorialDef editorialServicio)
        {
            this.editorialServicio = editorialServicio;
        }

        [HttpGet]
        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            return await editorialServicio.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<EditorialDto> GetByIdAsync(int id)
        {
            return await editorialServicio.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateAsync(CrearEditorial crearEditorialDto)
        {
            return await editorialServicio.CreateAsync(crearEditorialDto);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateAsync(int id, CrearEditorial editorialDto)
        {
            return await editorialServicio.UpdateAsync(id, editorialDto);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await editorialServicio.DeleteAsync(id);
        }
    }
}