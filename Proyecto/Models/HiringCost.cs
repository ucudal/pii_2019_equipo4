using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class HiringCost
    {
        [Key]
        public int HirCosId {get;set;}

        [Display(Name = "Nivel")]
        [Required]
        public int RolLvlId {get;set;}
        public RoleLevel level {get;set;}

        [Display(Name = "1 era. hora")]
        [Required]
        public float HirCosHourly {get;set;}

        [Display(Name = "Fracción u hora adicionales (15 minutos o una hora adicional es indistinto)")]
        [Required]
        public float HirCosAdditional {get;set;}

        [Display(Name = "Jornadas completas de 6 hs")]
        [Required]
        public float HirCosFull {get;set;}

    }
}