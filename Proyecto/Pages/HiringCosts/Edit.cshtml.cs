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

namespace Proyecto.Pages.HiringCosts
{
    public class EditModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public EditModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HiringCost HiringCost { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HiringCost = await _context.HiringCost
                .Include(h => h.level).FirstOrDefaultAsync(m => m.HirCosId == id);

            if (HiringCost == null)
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

            _context.Attach(HiringCost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HiringCostExists(HiringCost.HirCosId))
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

        private bool HiringCostExists(int id)
        {
            return _context.HiringCost.Any(e => e.HirCosId == id);
        }
    }
}