using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Microsoft.AspNetCore.Authorization;
using Proyecto.Areas.Identity.Data;
using Proyecto.Models;

namespace Proyecto.Pages_Technicians
{
    [Authorize(Roles=IdentityData.AdminRoleName)]
    public class DeleteModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public DeleteModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Technician Technician { get; set; }

        public string ErrorMessage {get;set;}
        public async Task<IActionResult> OnGetAsync(string id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Technician = await _context.GetTechnicianByIdAsync(id);

            if (Technician == null)
            {
                return NotFound();
            }
            if(saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
           
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Technician = await _context.GetTechnicianByIdAsync(id);

            if (Technician != null)
            {
                
                await _context.RemoveTechnicianAsync(Technician);
            }

            return RedirectToPage("./Index");
        }
    }
}
