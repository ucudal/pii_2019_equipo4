using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Proyecto.Models
{
    /// <summary>
    /// Define la relación de postulacion a un proyecto entre un técnico y un proyecto
    /// (relación 1 a 1) 
    /// Patrones
    /// Indirection
    /// Se asigna la responsabilidad de asociacion a esta clase intermedia para evitar el 
    /// acoplamiento directo entre Technician y Project
    /// Pure Fabrication
    /// Se asigna una responsabilidad altamente cohesiva a la clase Postulation, la cual esta poco acoplada
    /// </summary>
    public class Postulation
    {
        
        [Key]
        public string TechnicianID { get; set; }

        [Key]
        public string ProjectID { get; set; }

        [Required]
        public Technician Technician { get; set; } 

        [Required]
        public Project Project { get; set; }
        
    }
}