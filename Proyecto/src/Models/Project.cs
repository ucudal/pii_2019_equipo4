using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models
{

    /// <summary>
    /// Un proyecto del centro Ignis con ciertas especificaciones al cual tecnicos se pueden postular
    /// 
    /// Patron Experto:
    /// La clase Project es experta ya que posee la información necesaria para la creacion de un proyecto
    /// Contiene una lista de postulaciones, que referencian la relacion de los tecnicos a este proyecto
    /// SRP
    /// Las responsabilidades de un proyecto esta unicamente encapsulado en la clase Project 
    /// </summary>
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

        /// <summary>
        /// Lista de postulaciones de tecnicos a este proyecto 
        /// (relación de N tecnicos a 1 proyecto)
        /// </summary>
        /// <value>Lista de postulaciones</value>
        public IList<Postulation> Postulations {get;set;}

    }
}
