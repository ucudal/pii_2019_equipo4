using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto.Models;
using Proyecto.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Pages
{
    public class AllProjectsModel : PageModel
    {
        //public void OnGet()
        //{
        //}
        private readonly Proyecto.Data.ProjectContext _context;
        public AllProjectsModel(Proyecto.Data.ProjectContext context)
        {
            _context = context;
        }
        public ProjectContext ProjectContext;
        public IList<Project> Project {get;set;}
        [BindProperty(SupportsGet = true)]
        public string SearchString {get;set;}
        
        public SelectList Postulantes {get;set;}
        [BindProperty(SupportsGet =true)]
        public int postulado{get;set;}
        public async Task OnGetAsync()
        {
            var Projects = from p in _context.Project
                         select p;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Projects = Projects.Where(s => s.Title.Contains(SearchString));
            }

            Project = await Projects.ToListAsync();
        }     

        
    }
}