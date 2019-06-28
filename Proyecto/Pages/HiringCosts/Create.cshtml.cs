using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Pages.HiringCosts
{
    public class CreateModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public CreateModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RolLevelID"] = new SelectList(_context.RoleLevel, "RolLevelID", "RolLevelDescription");
            return Page();
        }

        [BindProperty]
        public HiringCost HiringCost { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HiringCost.Add(HiringCost);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}