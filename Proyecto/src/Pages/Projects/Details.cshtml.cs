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
using Microsoft.AspNetCore.Identity;

namespace Proyecto.Pages_Projects
{
    public class DetailsModel : PageModel
    {
        /// <summary>
        /// Referencia al contexto del proyecto
        /// Se agrega esta variable para cumplir con la ley de Demeter, Don't talk with strangers
        /// los mensajes se envian a un atributo de la clase, en vez de a un elemento ajeno.
        /// </summary>
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

            string TechnicianID = CurrentUserID.GetUserID(this.User);

            this.Technician = await _context.GetTechnicianByIdAsync(TechnicianID);
            Project = await _context.GetProjectByIdAsync(id);

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostUnPostulateTechnicianAsync(string id, string technicianToDeleteID)
        {
            Project ProjectToUpdate= await _context.Project.Include(p => p.Postulants)
            .ThenInclude(t => t.Technician).
            FirstOrDefaultAsync(p => p.ProjectID == id);
                await TryUpdateModelAsync<Project>(ProjectToUpdate);

            var technicianToDelete = ProjectToUpdate.Postulants.
            Where(t => t.TechnicianID == technicianToDeleteID).FirstOrDefault();
            /*
            try
            {
                Check.Precondition(ProjectToUpdate.Postulants.Remove(technicianToDelete),"ya no estas postulado");
            }
            catch (Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception?id=" + ex.Message);
            }
            */
            if(technicianToDelete != null)
            {
                ProjectToUpdate.Postulants.Remove(technicianToDelete);
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
                Project ProjectToUpdate = await _context.Project.Include(p => p.Postulants)
            .ThenInclude(t => t.Technician).
            FirstOrDefaultAsync(p => p.ProjectID == id);
                await TryUpdateModelAsync<Project>(ProjectToUpdate);

                Technician technicianToAdd = await _context.Technician.Where(a => a.Id == technicianToAddID).FirstOrDefaultAsync();
                
                if (technicianToAdd != null)
                {
                    //request 
                    var postulationToAdd = new Postulation()
                    {
                        TechnicianID = technicianToAddID,
                        Technician = technicianToAdd,
                        ProjectID =ProjectToUpdate.ProjectID,
                        Project = ProjectToUpdate
                    };
                    /*
                    try
                    {
                        Check.Precondition(ProjectToUpdate.Postulants.Add(postulationToAdd),"Ya estas postulado en el proyecto seleccionado");
                    }
                    catch(Check.PostconditionException ex)
                    {
                        return Redirect("https://localhost:5001/Exception?id=" + ex.Message);
                    }
                    ProjectToUpdate.Postulants.Add(postulationToAdd);
                    */
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
