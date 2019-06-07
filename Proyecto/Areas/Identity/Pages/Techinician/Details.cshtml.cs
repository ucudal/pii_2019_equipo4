using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Areas.Identity.Data;

namespace Proyecto.Areas.Identity.Pages.Techinician
{
    public class DetailsModel : PageModel
    {
        private readonly Proyecto.Areas.Identity.Data.ProyectoIdentityDbContext _context;

        public DetailsModel(Proyecto.Areas.Identity.Data.ProyectoIdentityDbContext context)
        {
            _context = context;
        }

        public Technician Technician { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Technician = await _context.Technician.FirstOrDefaultAsync(m => m.Id == id);

            if (Technician == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
