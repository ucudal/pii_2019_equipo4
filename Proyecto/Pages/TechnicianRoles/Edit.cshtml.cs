using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Proyecto.Pages.TechnicianRoles
{
    public class EditModel : PageModel
    {
        private readonly Project.Models.TechnicianRoleContext _context;

        public EditModel(Project.Models.TechnicianRoleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TechnicianRole TechnicianRole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TechnicianRole = await _context.TechnicianRole.FirstOrDefaultAsync(m => m.TecRolId == id);

            if (TechnicianRole == null)
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

            _context.Attach(TechnicianRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicianRoleExists(TechnicianRole.TecRolId))
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

        private bool TechnicianRoleExists(int id)
        {
            return _context.TechnicianRole.Any(e => e.TecRolId == id);
        }
    }
}
