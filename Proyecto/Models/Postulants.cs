using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public class Postulants
    {
        //public IList<Technician> Postulantes{get;set;}
        
        /*public void AddTechnician(Technician Technician)
        {
            Postulantes.Add(Technician);
        }*/
        internal static Task<IQueryable<Project>> ToListAsync()
        {
            throw new NotImplementedException();
        }

    }
}