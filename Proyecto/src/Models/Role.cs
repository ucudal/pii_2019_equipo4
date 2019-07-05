using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Proyecto.Models
{
    /// <summary>
    /// Define el rol de un tecnico
    /// </summary>
    public class Role 
    {
        /// <summary>
        /// El id del tipo de rol
        /// </summary>
        /// <value></value>
        [Key]
        public int RoleId {get;set;}

        /// <summary>
        /// El tipo de rol, ejemplo: Sonidista, Camarografo
        /// </summary>
        /// <value></value>
        [Required]
        [Display(Name = "Descripción")]
        public string RolDescription {get;set;}

        /// <summary>
        /// Nivel del rol, Basico o Avanzado
        /// </summary>
        /// <value></value>
        [Display(Name = "Nivel")]
        [Required]
        public int RolLvlId {get;set;}
        [Display(Name = "Nivel")]
        public RoleLevel level {get;set;}

        public IList<Technician> Technicians{get;set;}
    }
}