using AplicacionNetRazor.Datos;
using AplicacionNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionNetRazor.Pages.Profesores
{
    public class EditarModel : PageModel
    {
        private readonly AplicacionDBContext _contexto;
        public EditarModel(AplicacionDBContext contexto)
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
                var ProfesorDesdeBD = await _contexto.Profesor.FindAsync(Profesor.idProf);

                ProfesorDesdeBD.Nombre = Profesor.Nombre;
                ProfesorDesdeBD.Apellido = Profesor.Apellido;
                ProfesorDesdeBD.Esp = Profesor.Esp;
                ProfesorDesdeBD.Fecha_ing = Profesor.Fecha_ing;
                ProfesorDesdeBD.Fecha_nac = Profesor.Fecha_nac;

                _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return RedirectToPage("");

        }
    }
}
