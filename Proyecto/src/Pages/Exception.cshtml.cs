using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Proyecto.Pages
{
    public class ExceptionModel : PageModel
    {
        public string Error{get;set;}
        public IActionResult OnGet(string id)
        {
            Error = id;
            return Page();
        }
    }
}