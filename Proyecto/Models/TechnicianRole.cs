using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class TechnicianRole
    {
        [Key]
        public int TecRolId {get;set;}
        [Display(Name = "Description")]
        public string TecRolDsc {get;set;}
        [Display(Name = "Level")]
        public string TecRolLvl {get;set;}
    }
}