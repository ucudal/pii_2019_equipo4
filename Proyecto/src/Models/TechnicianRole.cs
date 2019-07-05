using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    public class TechnicianRole 
    {
        [Key]
        public int TecRolId {get;set;}
        
        [ForeignKey("Technician")]
        public string TechnicianId {get;set;}

        [ForeignKey("Role")]
        public int RoleId {get;set;}
        public Technician Technician {get;set;}
        public Role Role {get;set;}
    }
}