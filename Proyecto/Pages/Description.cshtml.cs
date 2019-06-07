using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Pages
{
    public class DescriptionModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;
        public DescriptionModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
        
            if (id == null)
            {
                Project = await _context.Project.FirstOrDefaultAsync();
            }
            else
            {
                Project = await _context.Project.FirstOrDefaultAsync(p => p.ProjectID == id);
            }

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}