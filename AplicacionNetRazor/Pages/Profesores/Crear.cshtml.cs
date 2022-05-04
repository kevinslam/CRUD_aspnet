using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionNetRazor.Pages.Profesores
{
    public class CrearModel : PageModel
    {
        private readonly AplicacionDBContext _contexto;

        public CrearModel(AplicacionDBContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Profesor Profesor { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _contexto.Add(Profesor);
            await _contexto.SaveChangesAsync();
            Mensaje = "Profesor creado exitosamente";
            return RedirectToPage("Index");
        }
        public void OnGet()
        {
        }
    }
}
