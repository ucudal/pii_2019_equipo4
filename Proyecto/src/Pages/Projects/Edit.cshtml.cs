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
    [Authorize(Roles = IdentityData.AdminAndClient)]
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
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Project.
            Where(p=> p.ProjectID==id).
            Include(a => a.Postulations).
            ThenInclude(t => t.Technician).
             AsNoTracking().FirstOrDefaultAsync(m => m.ProjectID == id);

            if (Project == null)
            {
                return NotFound();
            }

            // Populate the list of technicians in the viewmodel with the technician of the Project.
            this.Technicians = Project.Postulations.Select(t => t.Technician);

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
            
            try
            {
                Check.Precondition(OtherTechnicians !=null,"Error al cargar los otros técnicos");
            }
            catch(Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception?id=" +ex.Message);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var projToUpdate = await _context.Project.
            Include(p => p.Postulations)
            .ThenInclude(t => t.Technician).FirstOrDefaultAsync(p => p.ProjectID == id);

            if(await TryUpdateModelAsync<Project>(projToUpdate,"Project",i => i.Title,
            i => i.Description,i => i.StartDate))
        

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ProjectExists(Project.ProjectID))
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
        public async Task<IActionResult> OnPostDeleteTechnicianAsync(string id, string technicianToDeleteID)
        {
            
            Project projectToUpdate = await _context.Project.
            Include(p => p.Postulations)
            .ThenInclude(t => t.Technician).
            FirstOrDefaultAsync(p => p.ProjectID == id);
            
            await TryUpdateModelAsync<Project>(projectToUpdate);

            var technicianToDelete = projectToUpdate.Postulations.
            Where(t => t.TechnicianID == technicianToDeleteID).FirstOrDefault();
            //si hay un error al borrar un postulante de un proyecto aparece una excepcion
            try
                {
                    Check.Precondition(projectToUpdate.Postulations.Remove(technicianToDelete),"Error al borrar al postulante");
                }
                catch(Check.PreconditionException ex)
                {
                    return Redirect("https://localhost:5001/Exception?id=" +ex.Message);

                }

           

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!_context.ProjectExists(Project.ProjectID))
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
        public async Task<IActionResult> OnPostAddTechnicianAsync(string id, string technicianToAddID)
        
        {
            Project projToUpdate = await _context.Project.
            Include(p => p.Postulations)
            .ThenInclude(t => t.Technician).
            FirstOrDefaultAsync(p => p.ProjectID == id);
            
            await TryUpdateModelAsync<Project>(projToUpdate);
            
            


            if (technicianToAddID != null)
            {
                Technician technicianToAdd = await _context.Technician.Where(a => a.Id == technicianToAddID).FirstOrDefaultAsync();
                if (technicianToAdd != null)
                {
                    //request 
                    var postulationToAdd = new Postulation()
                    {
                        TechnicianID = technicianToAddID,
                        Technician = technicianToAdd,
                        ProjectID =projToUpdate.ProjectID,
                        Project = projToUpdate
                    };
                    projToUpdate.Postulations.Add(postulationToAdd);
                       
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ProjectExists(Project.ProjectID))
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

    }
}
