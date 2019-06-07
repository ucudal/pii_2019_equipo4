using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Models;

namespace Proyecto.Pages.RoleLevels
{
    public class CreateModel : PageModel
    {
        private readonly Proyecto.Models.ProjectContext _context;

        public CreateModel(Proyecto.Models.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RoleLevel RoleLevel { get; set; }

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