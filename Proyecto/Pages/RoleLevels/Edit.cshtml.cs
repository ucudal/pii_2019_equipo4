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

namespace Proyecto.Pages.RoleLevels
{
    public class EditModel : PageModel
    {
        private readonly ProjectContext _context;

        public EditModel(ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoleLevel RoleLevel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoleLevel = await _context.RoleLevel.FirstOrDefaultAsync(m => m.RolLvlId == id);

            if (RoleLevel == null)
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

            _context.Attach(RoleLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleLevelExists(RoleLevel.RolLvlId))
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

        private bool RoleLevelExists(int id)
        {
            return _context.RoleLevel.Any(e => e.RolLvlId == id);
        }
    }
}
