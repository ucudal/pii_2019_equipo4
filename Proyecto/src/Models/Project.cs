using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models
{
    /*Patrones
Expert: es experta en el conocimiento de la información
necesaria para la creacion de un proyecto
Creator: cumple con creator ya que agrega y contiene objetos de RoleLevel y Postulation
*/
    public class Project
    {
        public string ProjectID {get;set;}
        //requerimientos para el titulo
        [StringLength(60, MinimumLength = 0)]
        [Required]
        public string Title{get;set;}

        //requerimientos para la descripción
        [StringLength(180, MinimumLength = 0)]
        public string Description{get;set;}

        //muestra StartDate como Start Date, igual con EndDate
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate{get;set;}
    
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate{get;set;}

        public IList<Postulation> Postulants{get;set;}
        public RoleLevel RoleLevel{get;set;}
        
        //public ICollection<Technician> Technician{get;set;}

    }
}
