using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class RoleLevel 
    {
        [Key]
        public int RolLvlId {get;set;}

        [Required]
        [Display(Name = "Descripción")]
        public string RolLvlDsc{get; set;}
    }
}