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

        [TempData]
        public string Mensaje { get; set; }
        public async Task OnGet()
        {
            Cursos = await _contexto.Curso.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {
            if (ModelState.IsValid)
            {
                var CursoBorrar = await _contexto.Curso.FindAsync(id);

                if (CursoBorrar == null)
                {
                    return NotFound();
                }

                _contexto.Curso.Remove(CursoBorrar);
                await _contexto.SaveChangesAsync();
                Mensaje = "Curso eliminado exitosamente";
                return RedirectToPage("Index");
            }

            return RedirectToPage("");

        }
    }
}
