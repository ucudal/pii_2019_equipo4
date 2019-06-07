using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Pages.Roles
{
    public class EditModel : PageModel
    {
        private readonly Proyecto.Models.ProjectContext _context;

        public EditModel(Proyecto.Models.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Role Role { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Role = await _context.Role
                .Include(r => r.level).FirstOrDefaultAsync(m => m.RoleId == id);

            if (Role == null)
            {
                return NotFound();
            }
           ViewData["RolLvlId"] = new SelectList(_context.RoleLevel, "RolLvlId", "RolLvlDsc");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(Role.RoleId))
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

        private bool RoleExists(int id)
        {
            return _context.Role.Any(e => e.RoleId == id);
        }
    }
}
