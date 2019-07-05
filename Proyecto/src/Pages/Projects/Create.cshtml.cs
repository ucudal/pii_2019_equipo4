using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Data;
using Proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Proyecto.Areas.Identity.Data;

namespace Proyecto.Pages_Projects
{
    [Authorize(Roles = IdentityData.AdminAndClient)]
    public class CreateModel : PageModel
    {
        /// <summary>
        /// Referencia al contexto del proyecto
        /// Se agrega esta variable para cumplir con la ley de Demeter, Don't talk with strangers
        /// los mensajes se envian a un atributo de la clase, en vez de a un elemento ajeno.
        /// </summary>
        private readonly Proyecto.Data.ProjectContext _context;

        public CreateModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Project ProjectInDB = _context.Project.FirstOrDefault(p =>p.Title == Project.Title);
            //si hay un proyecto con el mismo nombre aparece una excepcion
            try
            {
                Check.Precondition(ProjectInDB == null,"Ya existe un proyecto con el mismo nombre");
            }
            catch(Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception?id=" +ex.Message);
            }
            
            await _context.AddProjectAsync(Project);

            return RedirectToPage("./Index");
        }
    }
}