using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Pages.RoleLevel
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
        ViewData["ProjectID"] = new SelectList(_context.Project, "ProjectID", "Title");
            return Page();
        }

        [BindProperty]
        public Proyecto.Models.RoleLevel RoleLevel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RoleLevel.Add(RoleLevel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}