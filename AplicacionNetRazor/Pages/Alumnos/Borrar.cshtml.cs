using AplicacionNetRazor.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionNetRazor.Pages.Alumnos
{
    public class BorrarModel : PageModel
    {
        private readonly AplicacionDBContext _contexto;
        public BorrarModel(AplicacionDBContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Modelos.Alumno Alumno { get; set; }

        [TempData]
        public string Mensaje { get; set; }
        public async Task OnGet(int id)
        {
            Alumno = await _contexto.Alumno.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var AlumnoBorrar = await _contexto.Alumno.FindAsync(Alumno.IdAlumno);

                if (AlumnoBorrar == null)
                {
                    return NotFound();
                }

                AlumnoBorrar.Eliminado = true;

                _contexto.SaveChangesAsync();
                Mensaje = "Alumno eliminado correctamente";
                return RedirectToPage("Index");
            }

            return RedirectToPage("");

        }
    }
}

