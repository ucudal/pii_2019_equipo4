using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Proyecto.Pages.TechnicianRoles
{
    public class DeleteModel : PageModel
    {
        private readonly Project.Models.TechnicianRoleContext _context;

        public DeleteModel(Project.Models.TechnicianRoleContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TechnicianRole = await _context.TechnicianRole.FindAsync(id);

            if (TechnicianRole != null)
            {
                _context.TechnicianRole.Remove(TechnicianRole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
