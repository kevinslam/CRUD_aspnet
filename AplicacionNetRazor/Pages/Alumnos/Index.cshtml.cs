using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetRazor.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        private readonly AplicacionDBContext _contexto;

        public IndexModel(AplicacionDBContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Alumno> Alumnos { get; set; }
        public async Task OnGet()
        {
            Alumnos = await _contexto.Alumno.ToListAsync();
        }
    }
}
