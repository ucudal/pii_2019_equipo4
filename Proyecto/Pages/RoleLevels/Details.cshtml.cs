using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Pages.RoleLevels
{
    public class DetailsModel : PageModel
    {
        private readonly Proyecto.Models.ProjectContext _context;

        public DetailsModel(Proyecto.Models.ProjectContext context)
        {
            _context = context;
        }

        public RoleLevel RoleLevel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoleLevel = await _context.RoleLevel.FirstOrDefaultAsync(m => m.RolLvlId == id);

            if (RoleLevel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
