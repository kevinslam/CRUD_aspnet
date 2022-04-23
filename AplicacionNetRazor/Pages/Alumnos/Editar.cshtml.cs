using AplicacionNetRazor.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AplicacionNetRazor.Pages.Alumnos
{
    public class EditarModel : PageModel
    {
        private readonly AplicacionDBContext _contexto;
        public EditarModel(AplicacionDBContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Modelos.Alumno Alumno { get; set; }
        public async Task OnGet(int id)
        {
            Alumno = await _contexto.Alumno.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var AlumnoDesdeBD = await _contexto.Alumno.FindAsync(Alumno.IdAlumno);

                AlumnoDesdeBD.Nombre = Alumno.Nombre;
                AlumnoDesdeBD.Apellido = Alumno.Apellido;
                AlumnoDesdeBD.Fecha_ing = Alumno.Fecha_ing;
                AlumnoDesdeBD.Hora_ing = Alumno.Hora_ing;
                AlumnoDesdeBD.Fecha_nac = Alumno.Fecha_nac;
                AlumnoDesdeBD.Cant_cursos = Alumno.Cant_cursos;
                AlumnoDesdeBD.Fecha_egr = Alumno.Fecha_egr;

                _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return RedirectToPage("");

        }
    }
}
