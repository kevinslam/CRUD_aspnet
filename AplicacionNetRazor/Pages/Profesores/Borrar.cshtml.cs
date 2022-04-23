using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AplicacionNetRazor.Pages.Profesores
{
    public class BorrarModel : PageModel
    {
        private readonly AplicacionDBContext _contexto;
        public BorrarModel(AplicacionDBContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Profesor Profesor { get; set; }
        public async Task OnGet(int id)
        {
            Profesor = await _contexto.Profesor.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ProfesorBorrar = await _contexto.Profesor.FindAsync(Profesor.idProf);

                if (ProfesorBorrar == null)
                {
                    return NotFound();
                }

                _contexto.Profesor.Remove(ProfesorBorrar);
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return RedirectToPage("");

        }
    }
}
