using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Proyecto.Pages.TechnicianRoles
{
    public class DetailsModel : PageModel
    {
        private readonly Project.Models.TechnicianRoleContext _context;

        public DetailsModel(Project.Models.TechnicianRoleContext context)
        {
            _context = context;
        }

        public TechnicianRole TechnicianRole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TechnicianRole = await _context.TechnicianRole.FirstOrDefaultAsync(m => m.TecRolId == id);

            if (TechnicianRole == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
