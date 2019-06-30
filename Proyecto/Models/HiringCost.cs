using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class HiringCost
    {
        [Key]
        public int HiringCostID {get;set;}

        [Display(Name = "Nivel")]
        [Required]
        public int RolLevelID {get;set;}
        public RoleLevel Level {get;set;}

        [Display(Name = "1 era. hora")]
        [Required]
        public float HiringCostHourly {get;set;}

        [Display(Name = "Fracción u hora adicionales (15 minutos o una hora adicional es indistinto)")]
        [Required]
        public float HiringCostAdditional {get;set;}

        [Display(Name = "Jornadas completas de 6 hs")]
        [Required]
        public float HiringCostFull {get;set;}

    }
}