using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Pages.RoleLevels
{
    public class IndexModel : PageModel
    {
        private readonly ProjectContext _context;

        public IndexModel(ProjectContext context)
        {
            _context = context;
        }

        public IList<RoleLevel> RoleLevel { get;set; }

        public async Task OnGetAsync()
        {
            RoleLevel = await _context.RoleLevel.ToListAsync();
        }
    }
}
