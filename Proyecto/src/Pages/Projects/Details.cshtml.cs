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

namespace Proyecto.Pages_Projects
{
    public class DetailsModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public DetailsModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }
        public IEnumerable<Technician> Technicians {get;set;}
        public Technician Technician{get;set;}
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.GetProjectByIdAsync(id);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostUnPostulateTechnicianAsync(string id, string technicianToDeleteID)
        {
            Project = await _context.GetProjectByIdAsync(id);
            var technicianToDelete = Project.Postulations.
            Where(t => t.TechnicianID == technicianToDeleteID).FirstOrDefault();
            if(technicianToDelete != null)
            {
                Project.Postulations.Remove(technicianToDelete);
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
        public async Task<IActionResult> OnPostAddPostulateAsync(string id, string technicianToAddID)
        
        {
            if (technicianToAddID != null)
            {
                Project = await _context.GetProjectByIdAsync(id);
                
                Technician technicianToAdd = await _context.Technician.Where(a => a.Id == technicianToAddID).FirstOrDefaultAsync();
                if (technicianToAdd != null)
                {
                    //request 
                    var postulationToAdd = new Postulation()
                    {
                        TechnicianID = technicianToAddID,
                        Technician = technicianToAdd,
                        ProjectID =Project.ProjectID,
                        Project = Project
                    };
                    Project.Postulations.Add(postulationToAdd);
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
