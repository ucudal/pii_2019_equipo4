using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto.Models;
using Microsoft.EntityFrameworkCore;


namespace Proyecto.Pages
{
    public class YourProjectsModel : PageModel
    {
        public void OnGet()
        {            
        }
        /*private Proyecto.Models.ProjectContext _context;
        
        public void projectdetails(Proyecto.Models.ProjectContext context)
        {
            _context =context;
        }

       // public DetailsModel(Proyecto.Models.ProjectContext context)
        //{
        //  _context = context;
        //}
          
        }
        /*public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
        
            if (id == null)
            {
                Project = await _context.Project.FirstOrDefaultAsync();
            }
            else
            {
                Project = await _context.Project.FirstOrDefaultAsync(m => m.ProjectID == id);
            }

            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }
        */

    }
}