using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionNetRazor.Pages.Cursos
{
    public class EditarModel : PageModel
    {
        private readonly AplicacionDBContext _contexto;

        public EditarModel(AplicacionDBContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Curso Curso { get; set; }
        public async Task OnGet(int id)
        {
            Curso = await _contexto.Curso.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursoDesdeBD = await _contexto.Curso.FindAsync(Curso.Id);

                CursoDesdeBD.NombreCurso = Curso.NombreCurso;
                CursoDesdeBD.CantidadClases = Curso.CantidadClases;
                CursoDesdeBD.Precio = Curso.Precio;

                _contexto.SaveChangesAsync();
                return RedirectToPage("Index"); 
            }

            return RedirectToPage("");

        }
    }
}
