using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura
{
    public class BibliotecaDbContext : DbContext
    {
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Editorial> Editorial { get; set; }
        public DbSet<Libro> Libro{get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder constructor)
    {
        var cadenaConexion = @"Server=(localdb)\MSSQLLocalDB; DataBase=ValladaresPrueba;Trusted_Connection=True";
        constructor.UseSqlServer(cadenaConexion);
    }
}
}
