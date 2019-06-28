using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Pages.RoleLevels
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectContext _context;

        public DeleteModel(ProjectContext context)
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

            RoleLevel = await _context.RoleLevel.FirstOrDefaultAsync(m => m.RolLevelID == id);

            if (RoleLevel == null)
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

            RoleLevel = await _context.RoleLevel.FindAsync(id);

            if (RoleLevel != null)
            {
                _context.RoleLevel.Remove(RoleLevel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
