using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;

namespace Proyecto.Pages.TechnicianRoles
{
    public class CreateModel : PageModel
    {
        private readonly Project.Models.TechnicianRoleContext _context;

        public CreateModel(Project.Models.TechnicianRoleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TechnicianRole TechnicianRole { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TechnicianRole.Add(TechnicianRole);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}