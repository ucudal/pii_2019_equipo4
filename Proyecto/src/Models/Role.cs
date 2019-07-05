using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Proyecto.Models
{
    public class Role 
    {
        [Key]
        public int RoleId {get;set;}

        [Required]
        [Display(Name = "Descripción")]
        public string RolDsc {get;set;}

        [Display(Name = "Nivel")]
        [Required]
        public int RolLvlId {get;set;}
        [Display(Name = "Nivel")]
        public RoleLevel level {get;set;}

        public IList<Technician> Technicians{get;set;}
    }
}