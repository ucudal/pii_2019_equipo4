using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class RoleLevel 
    {
        /// <summary>
        /// El identificador del nivel del rol
        /// </summary>
        /// <value></value>
        [Key]
        public int RolLvlId {get;set;}

        /// <summary>
        /// Marca si es un tecnico basico o avanzado.
        /// </summary>
        /// <value></value>
        [Required]
        [Display(Name = "Descripción")]
        public string RolLvlDescription{get; set;}
    }
}