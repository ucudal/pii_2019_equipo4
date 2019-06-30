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
        public int ProjectId{get;set;}
        public int TechnicianId{get;set;}

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList RoleFilter{get;set;}

        [BindProperty(SupportsGet = true)]
        public string RoleLevel { get; set; }

        public IList<Project> Project { get;set; }

        public async Task OnGetAsync(int? id,int? TechniciaNID)
        {
            IQueryable<string> genreQuery = from m in _context.Project
                                            orderby m.RoleLevel.roleLevel
                                            select m.RoleLevel.roleLevel;
            RoleFilter = new SelectList(await genreQuery.Distinct().ToListAsync());


            IndexData = new ProjectIndexData();
            IndexData.ProjectsIndex = await _context.Project.Where(s=> !string.IsNullOrEmpty(SearchString)?
            s.Title.Contains(SearchString) : true)
            .Where(x => !string.IsNullOrEmpty(RoleLevel) ? x.RoleLevel.roleLevel == RoleLevel : true)
            .Include(r => r.RoleLevel).Include(c => c.Postulants).ThenInclude(c => c.Technician)
            .AsNoTracking().ToListAsync();
            
        
            if (id != null)
            {
                ProjectId = id.Value;
                Project project = IndexData.ProjectsIndex.Where(p => p.ProjectID == id.Value).Single();
                IndexData.TechniciansIndex = project.Postulants.Select(t => t.Technician);
            }
            if (TechniciaNID !=null )
            {
                TechniciaNID = id.Value;
            }
        }
    }
}
