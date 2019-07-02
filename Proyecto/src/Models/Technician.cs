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

    /// <summary>
    /// Principios:
    /// Liskov, polimorfismo, Un Technician puede ser usado como ApplicationUser
    /// </summary>
    public class Technician : ApplicationUser
    {


        /// <summary>
        /// Lista de todas las postulaciones a las que se a inscripto el tecnico
        /// </summary>
        /// <value>Lista de Postulaciones</value>
        public List<Postulation> Postulations {get;set;}
    }
}
