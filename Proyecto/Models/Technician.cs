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

    // Add profile data for application users by adding properties to the Technician class
    public class Technician : Person
    {
        
        public List<Postulation> Postulants {get;set;}
    }
}
