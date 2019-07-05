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
        public ExceptionModel()
        {
            
        }
        public string Error{get;set;}
        public IActionResult OnGet(string id)
        {
            if(id ==null)
            {
                return NotFound();
            }
            Error = id;
            return Page();
        }
    }
}