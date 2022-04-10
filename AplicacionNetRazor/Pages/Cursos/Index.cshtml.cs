using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetRazor.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly AplicacionDBContext _contexto;

        public IndexModel(AplicacionDBContext contexto) 
        {
            _contexto = contexto;
        }

        public IEnumerable<Curso> Cursos { get; set; }
        public async Task OnGet()
        {
            Cursos = await _contexto.Curso.ToListAsync();
        }
    }
}
