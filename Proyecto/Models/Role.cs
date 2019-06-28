using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Role 
    {
        [Key]
        public int RoleId {get;set;}

        [Required]
        [Display(Name = "Descripción")]
        public string RolDescription {get;set;}

        [Display(Name = "Nivel")]
        [Required]
        public int RolLevelID {get;set;}
        public RoleLevel Level {get;set;}
    }
}