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

namespace Proyecto.Pages_Technicians
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
        public Technician Technician { get; set; }
        
        public IEnumerable <Role> Roles {get;set;}
        public string SearchString { get; set; }
        public IEnumerable<Proyecto.Models.Role> otherRoles { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Technician = await _context.Technician.
            Where(t => t.Id == id).
            Include(r => r.TechnicianRoles).
            ThenInclude(k => k.Role).
            ThenInclude(j => j.level).
            AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (Technician == null)
            {
                return NotFound();
            }
            this.Roles = Technician.TechnicianRoles.Select(n => n.Role);

            string roleFilter ="";
            if(this.SearchString != null)
            {
                roleFilter =this.SearchString.ToUpper();
            }
            
            this.otherRoles = await _context.Role
            .Where(t => !Roles.Contains(t)).
            Where(t =>! string.IsNullOrEmpty(roleFilter) ? t.RolDsc.ToUpper().
            Contains(roleFilter) : true).Include(p=>p.level).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var tecToUpdate = await _context.Technician.
            Include(p => p.TechnicianRoles).
            ThenInclude(r => r.Role).
            FirstOrDefaultAsync(p => p.Id == id);
            if(await TryUpdateModelAsync<Technician>(tecToUpdate,"Technician",i => i.Name
            ))

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TechnicianExists(Technician.Id))
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
        public async Task<IActionResult> OnPostAddRoleAsync(string id, int roleToAddId)
        {
            Technician tecToUpdate = await _context.Technician.
           Include(s => s.TechnicianRoles).
           ThenInclude(f => f.Role).
           ThenInclude(j => j.level).
           AsNoTracking().
           FirstOrDefaultAsync(m => m.Id == id);

            await TryUpdateModelAsync<Technician>(tecToUpdate);

            if (roleToAddId > 0)
            {
                Role RoleToAdd = await _context.Role.Where(a => a.RoleId == roleToAddId).FirstOrDefaultAsync();
                var TechnicianRole = new TechnicianRole()
                {
                    TechnicianId = id,
                    RoleId = roleToAddId,
                    Role = RoleToAdd,
                    Technician = tecToUpdate
                };
                tecToUpdate.TechnicianRoles.Add(TechnicianRole);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return Redirect(Request.Path + $"?id={id}");
        }

        public async Task<IActionResult> OnPostDeleteRoleAsync(string id, int roleToDeleteID)
        {

            Technician technicianToUpdate = await _context.Technician.
            Include(p => p.TechnicianRoles)
            .ThenInclude(r => r.Role).ThenInclude(m => m.level).
            FirstOrDefaultAsync(p => p.Id == id);

            await TryUpdateModelAsync<Technician>(technicianToUpdate);

            var roleToDelete = technicianToUpdate.TechnicianRoles.
            Where(t => t.RoleId == roleToDeleteID && t.TechnicianId == id).FirstOrDefault();
            if (roleToDelete != null)
            {
                technicianToUpdate.TechnicianRoles.Remove(roleToDelete);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return Redirect(Request.Path + $"?id={id}");

        }

    }
}
