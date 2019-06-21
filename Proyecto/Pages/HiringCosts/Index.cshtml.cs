using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Pages.HiringCosts
{
    public class IndexModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public IndexModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        public IList<HiringCost> HiringCost { get;set; }

        public async Task OnGetAsync()
        {
            HiringCost = await _context.HiringCost
                .Include(h => h.level).ToListAsync();
        }
    }
}
