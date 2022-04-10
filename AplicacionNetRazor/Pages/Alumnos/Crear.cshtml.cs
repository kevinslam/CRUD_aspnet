using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionNetRazor.Pages.Alumnos
{
    public class CrearModel : PageModel
    {
        private readonly AplicacionDBContext _contexto;

        public CrearModel(AplicacionDBContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Alumno Alumno { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contexto.Add(Alumno);
            await _contexto.SaveChangesAsync();
            return RedirectToPage("Index");
        }
        public void OnGet()
        {
        }
    }
}
