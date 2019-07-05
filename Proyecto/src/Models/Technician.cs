using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proyecto.Areas.Identity.Data;

namespace Proyecto.Models
{
    /*
    Principios
    Principio de sustitución de Liskov:por cada objeto de la clase Person 
    hay un objeto Technician y otro objeto Client.*/

    /// <summary>
    /// La clase Technician representa un tecnico con diferentes aptitudes, 
    /// con la capacidad de inscribirse a diferentes proyectos.
    /// 
    /// Principios:
    /// Liskov, polimorfismo 
    /// Un Technician puede ser usado como ApplicationUser y/o IdentityUser, 
    /// ya que Technician es un ApplicationUser y ApplicationUser es un IdentityUser,
    /// esto le permite a Technician utilizar funciones de ambas.
    /// SRP
    /// Las responsabilidades de un tecnico estan unicamente encapsuladas en la clase Technician 
    /// Composición
    /// Technician tiene un rol al cual se le delega el comportamiento relacionado a roles ---ACTUALIZAR---
    /// </summary>
    public class Technician : ApplicationUser
    {

        /// <summary>
        /// Lista de todas las postulaciones a las que se a inscripto el tecnico
        /// (relación de 1 tecnico a N proyectos)
        /// </summary>
        /// <value>Lista de Postulaciones</value>
        public List<Postulation> Postulations {get;set;}
        [Display(Name = "Roles")]
        public List <TechnicianRole> TechnicianRoles {get;set;}
    }
}
