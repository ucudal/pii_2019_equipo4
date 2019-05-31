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
    public class IndexModel : PageModel
    {
        private readonly Project.Models.TechnicianRoleContext _context;

        public IndexModel(Project.Models.TechnicianRoleContext context)
        {
            _context = context;
        }

        public IList<TechnicianRole> TechnicianRole { get;set; }

        public async Task OnGetAsync()
        {
            TechnicianRole = await _context.TechnicianRole.ToListAsync();
        }
    }
}
