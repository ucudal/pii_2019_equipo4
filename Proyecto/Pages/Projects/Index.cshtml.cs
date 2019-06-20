using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;
using Proyecto.Models.ProjectViewModel;

namespace Proyecto.Pages_Projects
{
    public class IndexModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public IndexModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }
        public ProjectIndexData IndexData {get;set;}
        public int ProjectId{get;set;}
        public int TechnicianId{get;set;}

        public IList<Project> Project { get;set; }

        public async Task OnGetAsync(int? id,int? TechniciaNID)
        {
            IndexData = new ProjectIndexData();
            IndexData.ProjectsIndex = await _context.Project.Include(c => c.Postulants).ThenInclude(t => t.Technician).AsNoTracking().ToListAsync();
            if (id != null)
            {
                ProjectId = id.Value;
                Project project = IndexData.ProjectsIndex.Where(p => p.ProjectID == id.Value).Single();
                IndexData.TechniciansIndex = project.Postulants.Select(t => t.Technician);
            }
            if (TechniciaNID !=null )
            {
                ViewData["TechnicianID"] = TechniciaNID.Value;
                var selectedCourse = IndexData.TechniciansIndex.Where(x => x.TechnicianID == TechniciaNID).Single();
                await _context.Entry(selectedCourse).Collection(x => x.Postulants).LoadAsync();
                foreach (Postulation postulation in selectedCourse.Postulants)
                {
                    await _context.Entry(postulation).Reference(x => x.Technician).LoadAsync();
                }
                IndexData.Cast = selectedCourse.Postulants;
            }
        }
    }
}
