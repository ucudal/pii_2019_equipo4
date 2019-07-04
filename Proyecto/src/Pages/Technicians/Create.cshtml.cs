using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Proyecto.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Pages_Technicians
{
    [Authorize(Roles=IdentityData.AdminRoleName)]
    public class CreateModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public CreateModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Technician Technician { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            await _context.AddTechnicianAsync(Technician);

            return RedirectToPage("./Index");
        }
    }
}