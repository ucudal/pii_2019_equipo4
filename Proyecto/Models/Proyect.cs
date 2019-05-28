using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Project
    {
        public int ProjectID {get;set;}
        public string Title{get;set;}

        public string Description{get;set;}

        public string StartDate{get;set;}
        public string EndDate{get;set;}

        //public IList<postulants> postulants = new IList<postulants>();

    }
}