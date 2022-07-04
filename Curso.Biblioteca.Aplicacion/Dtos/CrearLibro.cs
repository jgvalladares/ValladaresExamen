using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Dtos
{
    public class CrearLibro
    {
        public int AutorId { get; set; }
        internal int EditorialId { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
    }
}
