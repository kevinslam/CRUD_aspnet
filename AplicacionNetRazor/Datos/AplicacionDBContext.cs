using AplicacionNetRazor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetRazor.Datos
{
    public class AplicacionDBContext: DbContext
    {
        public AplicacionDBContext(DbContextOptions<AplicacionDBContext> options) : base(options)
        {
        }

        //modelos
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
    }
}
