using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public class RoleLevel
    {
        [Key]
        public int ProjectID{get;set;}
        
        
        [StringLength(60, MinimumLength = 3)]
        [Display(Name ="Nivel del Técnico")]
        public string roleLevel{get;set;}
        
        public Project Project{get;set;}
    }



}