using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models.ProjectViewModel
{
    public class ProjectIndexData
    {
        public IEnumerable<Project> ProjectsIndex { get; set; }

        public IEnumerable<Technician> TechniciansIndex { get; set; }

        public IEnumerable<Postulation> Cast { get; set; }
    }
}