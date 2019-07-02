using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Proyecto.Areas.Identity.Data;

namespace Proyecto.Pages_Technicians
{
    [Authorize(Roles=IdentityData.AdminRoleName)]
    public class DetailsModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public DetailsModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        public Technician Technician { get; set; }
        public IEnumerable<Project> Projects{get;set;}

        public IEnumerable<Project> LoadProjects(){
            var db = _context;
            IEnumerable<Project> e = Enumerable.Empty<Project>();
            try {
                foreach(Postulation Postulations in db.Postulation.Where(p=> p.TechnicianID == Technician.Id)){
                    e = e.Concat(db.Project.Where(t => t.ProjectID == Postulations.ProjectID).AsEnumerable());
                }
           }catch{}
            return e;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

           Technician = await _context.GetTechnicianByIdAsync(id);
           
           Projects = LoadProjects();

            if (Technician == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
