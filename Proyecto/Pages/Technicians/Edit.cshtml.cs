using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Proyecto.Areas.Identity.Data;

namespace Proyecto.Pages_Technicians
{
    [Authorize(Roles=IdentityData.AdminRoleName)]
    public class EditModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public EditModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Technician Technician { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Technician = await _context.GetTechnicianByIdAsync(id);

            if (Technician == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Technician).State = EntityState.Modified; // ACA FALLA EL EDIT

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TechnicianExists(Technician.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }
        
    }
}
