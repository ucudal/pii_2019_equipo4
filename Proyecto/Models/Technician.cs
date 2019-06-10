using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models
{

    // Add profile data for application users by adding properties to the Technician class
    public class Technician : Person
    {
        [Key]
        
        [Display(Name = "Awarded Best Technician")]
        public bool AwardedBestActor { get; set; }

        public List<Postulation> Appereances { get; set; }
    }
}
