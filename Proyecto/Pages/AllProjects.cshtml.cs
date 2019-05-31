using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Proyecto.Pages
{
    [Authorize]
    public class AllProjectsModel : PageModel
    {
        public void OnGet()
        {
        }
        
    }
}