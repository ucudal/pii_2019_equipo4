using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Pages.Roles
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
        ViewData["RolLvlId"] = new SelectList(_context.RoleLevel, "RolLvlId", "RolLvlDescription");
            return Page();
        }

        [BindProperty]
        public Role Role { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Role.Add(Role);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}