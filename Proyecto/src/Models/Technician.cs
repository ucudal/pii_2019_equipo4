using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proyecto.Areas.Identity.Data;

namespace Proyecto.Models
{
    /*
    Principios
    Principio de sustitución de Liskov:por cada objeto de la clase Person 
    hay un objeto Technician y otro objeto Client.*/

    // Add profile data for application users by adding properties to the Technician class
    public class Technician : ApplicationUser
    {
        public List<Postulation> Postulants {get;set;}
        [Display(Name = "Roles")]
        public IEnumerable <TechnicianRole> TechnicianRoles {get;set;}
    }
}
