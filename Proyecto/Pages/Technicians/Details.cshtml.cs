using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Pages.Technicians
{
    public class DetailsModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public DetailsModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        public Technician Technician { get; set; }

        public async Task<IActionResult> OnGetAsync(bool? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Technician = await _context.Technician.FirstOrDefaultAsync(m => m.AwardedBestActor == id);

            if (Technician == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
