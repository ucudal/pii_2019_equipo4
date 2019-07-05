using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;
using Proyecto.Models.ProjectViewModel;
using Microsoft.AspNetCore.Authorization;
using Proyecto.Areas.Identity.Data;

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
        public string ProjectId{get;set;}
        public string TechnicianId{get;set;}

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList RoleFilter{get;set;}

        [BindProperty(SupportsGet = true)]
        public IList<Project> Project { get;set; }

        public async Task OnGetAsync(string id,string TechniciaNID)
        {
            
            IndexData = new ProjectIndexData();
            IndexData.ProjectsIndex = await _context.Project.Where(s=> !string.IsNullOrEmpty(SearchString)?
            s.Title.Contains(SearchString) : true)
            .Include(c => c.Postulants).ThenInclude(c => c.Technician)
            .AsNoTracking().ToListAsync();
            
        
            if (id != null)
            {
                ProjectId = id;
                Project project = IndexData.ProjectsIndex.Where(p => p.ProjectID == id).Single();
                IndexData.TechniciansIndex = project.Postulants.Select(t => t.Technician);
            }
            if (TechniciaNID !=null )
            {
                TechniciaNID = id;
            }
        }
    }
}
