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
    public class IndexModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public IndexModel(Proyecto.Data.ProjectContext context)
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
