using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class RoleLevel 
    {
        [Key]
        public int RolLevelID {get;set;}

        [Required]
        [Display(Name = "Descripción")]
        public string RolLevelDescription{get; set;}
    }
}