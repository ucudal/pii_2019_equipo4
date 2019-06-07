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
    public class IndexModel : PageModel
    {
        private readonly Proyecto.Areas.Identity.Data.ProyectoIdentityDbContext _context;

        public IndexModel(Proyecto.Areas.Identity.Data.ProyectoIdentityDbContext context)
        {
            _context = context;
        }

        public IList<Technician> Technician { get;set; }

        public async Task OnGetAsync()
        {
            Technician = await _context.Technician.ToListAsync();
        }
    }
}
