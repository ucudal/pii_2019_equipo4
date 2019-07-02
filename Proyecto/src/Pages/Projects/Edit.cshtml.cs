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
using Microsoft.AspNetCore.Authorization;
using Proyecto.Areas.Identity.Data;

namespace Proyecto.Pages_Projects
{
    [Authorize(Roles = IdentityData.AdminRoleName)]
    public class EditModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public EditModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }

        public IEnumerable<Technician> Technicians {get;set;}

        public IEnumerable<Proyecto.Models.Technician> OtherTechnicians{get;set;}

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.
            Where(p=> p.ProjectID==id).
            Include(r => r.RoleLevel).
            Include(a => a.Postulants).
            ThenInclude(t => t.Technician).
             AsNoTracking().FirstOrDefaultAsync(m => m.ProjectID == id);

            if (Project == null)
            {
                return NotFound();
            }

            // Populate the list of technicians in the viewmodel with the technician of the Project.
            this.Technicians = Project.Postulants.Select(t => t.Technician);

            string roleFilter ="";
            if(this.SearchString != null)
            {
                roleFilter =this.SearchString.ToUpper();
            }
            // Populate the list of all other Technicians with all technicians not included in the project's technician and
            // included in the search filter.
            this.OtherTechnicians = await _context.Technician
            .Where(t => !Technicians.Contains(t)).
            Where(t =>! string.IsNullOrEmpty(roleFilter) ? t.Name.ToUpper().
            Contains(roleFilter) : true).ToListAsync();


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var projectToUpdate = await _context.Project.
            Include(r => r.RoleLevel).Include(p => p.Postulants)
            .ThenInclude(t => t.Technician).FirstOrDefaultAsync(p => p.ProjectID == id);

            if(await TryUpdateModelAsync<Project>(projectToUpdate,"Project",i => i.Title,
            i => i.Description,i => i.StartDate, i =>i.EndDate, i => i.RoleLevel))

            if(string.IsNullOrWhiteSpace(projectToUpdate.RoleLevel?.roleLevel))
            {
                projectToUpdate.RoleLevel = null;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.ProjectID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostDeleteTechnicianAsync(int id, int technicianToDeleteID)
        {
            Project projectToUpdate = await _context.Project.
            Include(r => r.RoleLevel).Include(p => p.Postulants)
            .ThenInclude(t => t.Technician).
            FirstOrDefaultAsync(p => p.ProjectID == id);
            
            await TryUpdateModelAsync<Project>(projectToUpdate);

            var technicianToDelete = projectToUpdate.Postulants.
            Where(t => t.TechnicianID == technicianToDeleteID).FirstOrDefault();
            if(technicianToDelete != null)
            {
                projectToUpdate.Postulants.Remove(technicianToDelete);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!ProjectExists(Project.ProjectID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Redirect(Request.Path + $"?id={id}");

        }
        public async Task<IActionResult> OnPostAddTechnicianAsync(int? id, int? technicianToAddID)
        //actor ToAddID corresponde a @actortoAddId
        //Add actor corresponde a AddActor
        {
            Project projectToUpdate = await _context.Project.
            Include(r => r.RoleLevel).Include(p => p.Postulants)
            .ThenInclude(t => t.Technician).
            FirstOrDefaultAsync(p => p.ProjectID == id);

            await TryUpdateModelAsync<Project>(projectToUpdate);


            if (technicianToAddID != null)
            {
                Technician technicianToAdd = await _context.Technician.Where(a => a.ID == technicianToAddID).FirstOrDefaultAsync();
                if (technicianToAdd != null)
                {
                    //request 
                    var postulationToAdd = new Postulation()
                    {
                        TechnicianID = technicianToAddID.Value,
                        Technician = technicianToAdd,
                        ProjectID =projectToUpdate.ProjectID,
                        Project = projectToUpdate
                    };
                    projectToUpdate.Postulants.Add(postulationToAdd);
                       
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.ProjectID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect(Request.Path + $"?id={id}");
        }

        private bool ProjectExists(int id)
            
        {
                return _context.Project.Any(e => e.ProjectID == id);
        }
    }
}