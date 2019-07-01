using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Pages.RoleLevel
{
    public class DetailsModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public DetailsModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        public Proyecto.Models.RoleLevel RoleLevel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoleLevel = await _context.RoleLevel
                .Include(r => r.Project).FirstOrDefaultAsync(m => m.ProjectID == id);

            if (RoleLevel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
