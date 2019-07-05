using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace Proyecto.Areas.Identity.Pages.Users
{
    [Authorize(Roles=IdentityData.AdminAndClient)] // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class DetailsModel : PageModel
    {
        private readonly Proyecto.Data.ProjectContext _context;

        public DetailsModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }

        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
