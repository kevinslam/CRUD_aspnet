using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetRazor.Pages.Profesores
{
    public class IndexModel : PageModel
    {
        private readonly AplicacionDBContext _contexto;

        public IndexModel(AplicacionDBContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Profesor> Profesores { get; set; }
        public async Task OnGet()
        {
            Profesores = await _contexto.Profesor.ToListAsync();
        }
    }
}
