using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Project
    {
        public int ProjectID {get;set;}
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
/*
        internal static Task<IQueryable<Project>> ToListAsync()
        {
            throw new NotImplementedException();
        }

        public IList<postulants> postulants = new IList<postulants>();
*/
    }
}