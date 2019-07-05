using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Proyecto.Areas.Identity.Data;

namespace Proyecto.Pages_Projects
{
    [Authorize(Roles=IdentityData.AdminAndClient)]
    public class DeleteModel : PageModel
    {
        /// <summary>
        /// Referencia al contexto del proyecto
        /// Se agrega esta variable para cumplir con la ley de Demeter, Don't talk with strangers
        /// los mensajes se envian a un atributo de la clase, en vez de a un elemento ajeno.
        /// </summary>
        private readonly Proyecto.Data.ProjectContext _context;

        public DeleteModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            //Don't Talk with Strangers
            Project = await _context.GetProjectByIdAsync(id);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.GetProjectByIdAsync(id);

            if (Project != null)
            {}
               try
               {
                  
                   Check.Precondition(_context.RemoveProjectAsync(Project) !=null,"No se pudo borrar el Proyecto");
               }
               catch(Check.PreconditionException ex)
               {
                   return Redirect("https://localhost:5001/Exception?id=" +ex.Message);
               }
               finally
               {
                   Check.Postcondition(await _context.GetProjectByIdAsync(Project.ProjectID) ==null,"Borrado correctamente");
                    
               }
                
            

            return RedirectToPage("./Index");
        }
    }
}
