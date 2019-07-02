using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Proyecto.Models
{
    /// <summary>
    /// Define la relación de postulacion a un proyecto entre un técnico y un proyecto
    /// (relación 1 a 1) 
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