using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Proyecto.Data;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public static class SeedProjectTechnician
    {
        public static void Initialize(ProjectContext context)
        {
            SeedTechnician(context);
            SeedProject(context);
            SeedPostulations(context);
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProjectContext>>()))
            {
                SeedTechnician(context);
                SeedProject(context);
                SeedPostulations(context);
                SeedRoleLevels(context);
                SeedRoles(context);
                SeedTechnicianRoles(context);
            }
        }

        private static void SeedProject(ProjectContext context)
        {
            // Look for any movies.
            if (context.Project.Any())
            {
                return;   // DB has been seeded
            }
            context.Project.AddRange(GetSeedingProjects());
            context.SaveChanges();
        }
        public static List<Project> GetSeedingProjects()
        {
            return new List<Project>()
            {

                new Project
                {
                    Title = "Proyecto radial",
                    Description ="Para radio nacional del interior, se busca persona con disponibilidad de viajar",
                    StartDate = DateTime.Parse("1989-2-12"),
                    EndDate =DateTime.Parse("2000-2-12")

                },

                new Project
                {
                    Title = "Proyecto cinematográfico nacional",
                    Description ="Para empresa audiovisual nacional, se busca camarógrafo con experiencia",
                    StartDate = DateTime.Parse("1989-2-12"),
                    EndDate =DateTime.Parse("2000-2-12")
                },

                new Project
                {
                    Title = "Proyecto cinematográfico internacional",
                    Description ="Para empresa audiovisual internacional, se busca sonidista",
                    StartDate = DateTime.Parse("1989-2-12"),
                    EndDate =DateTime.Parse("2000-2-12")
                },

                new Project
                {

                    Title = "Corto",
                    Description ="Se buscan sonidistas",
                    StartDate = DateTime.Parse("1989-2-12"),
                    EndDate =DateTime.Parse("2000-2-12")
                }
            };

        }

        private static void SeedTechnician(ProjectContext context)
        {
            // Look for any actor.
            if (context.Technician.Any())
            {
                return;   // DB has been seeded
            }
            context.Technician.AddRange(GetSeedingTechnicians());
            context.SaveChanges();
        }

        public static List<Technician> GetSeedingTechnicians()
        {
            return new List<Technician>()
            {
                new Technician
                {

                    Name = "Mia Wallace",
                    BirthDate = DateTime.Parse("1948-3-14")

                },

                new Technician
                {
                    Name = "Morty Smith",
                    BirthDate = DateTime.Parse("1961-11-19")

                },

                new Technician
                {
                    Name = "Vincent Vega",
                    BirthDate = DateTime.Parse("1950-9-21")

                },

                new Technician
                {
                    Name = "Jules Winnfield",
                    BirthDate = DateTime.Parse("1952-7-1")

                },

                new Technician
                {
                    Name = "Todd Chavez",
                    BirthDate = DateTime.Parse("1949-10-8")

                },

                new Technician
                {
                    Name = "Daisy Domergue",
                    BirthDate = DateTime.Parse("1907-5-26")

                },

                new Technician

                {
                    Name = "Sarah Lynn",
                    BirthDate = DateTime.Parse("1917-7-7")

                }
            };
        }
        private static void SeedClient(ProjectContext context)
        {
            // Look for any actor.
            if (context.Client.Any())
            {
                return;   // DB has been seeded
            }
            context.Client.AddRange(GetSeedingClients());
            context.SaveChanges();
        }

        public static List<Client> GetSeedingClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    
                    Name = "Donald Draper",
                    BirthDate = DateTime.Parse("1948-3-14")
                   
                },

                new Client
                {
                    Name = "Peggy Olson",
                    BirthDate = DateTime.Parse("1961-11-19")
                   
                },

                new Client
                {
                    Name = "Roger Sterling",
                    BirthDate = DateTime.Parse("1950-9-21")
                    
                },

                new Client
                {
                    Name = "Peter Campbell",
                    BirthDate = DateTime.Parse("1952-7-1")
                    
                },

            };
        }

        private static void SeedPostulations(ProjectContext context)
        {
            // Look for any appereance.
            if (context.Postulation.Any())
            {
                return;   // DB has been seeded
            }

            foreach (Postulation a in GetSeedingPostulations(context))
            {
                context.Postulation.Add(a);
            }
            context.SaveChanges();
        }

        public static List<Postulation> GetSeedingPostulations(ProjectContext context)
        {
            return new List<Postulation>()
            {
                new Postulation
                {
                    TechnicianID = context.Technician.Single(t => t.Name == "Vincent Vega").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto radial").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Morty Smith").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto radial").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Vincent Vega").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto cinematográfico nacional").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Jules Winnfield").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto cinematográfico nacional").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Todd Chavez").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto cinematográfico nacional").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Vincent Vega").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto cinematográfico internacional").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Jules Winnfield").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto cinematográfico internacional").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Todd Chavez").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto cinematográfico internacional").ProjectID
                },

                 new Postulation
                 {
                     TechnicianID = context.Technician.Single(a => a.Name == "Daisy Domergue").Id,
                     ProjectID = context.Project.Single(m => m.Title == "Corto").ProjectID
                 },

                 new Postulation {
                     TechnicianID = context.Technician.Single(a => a.Name == "Sarah Lynn").Id,
                     ProjectID = context.Project.Single(m => m.Title == "Corto").ProjectID
                 }
            };

        }
        private static void SeedRoleLevels(ProjectContext context)
        {
            if (context.RoleLevel.Any())
            {
                return;   // DB has been seeded
            }
            context.RoleLevel.AddRange(
                    new RoleLevel
                    {
                        RolLvlDescription = "Básico"
                    },

                    new RoleLevel
                    {
                        RolLvlDescription = "Avanzado"
                    }
                );
            context.SaveChanges();
        }
        private static void SeedRoles(ProjectContext context)
        {
            if (context.Role.Any())
            {
                return;   // DB has been seeded
            }
            context.Role.AddRange(
                    new Role
                    {
                        RolDescription = "Foto fija",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Asistente de cámara",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Asistente de producción",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Asistente de dirección",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Asistente de arte (escenografía, vestuario, utilería)",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Sonidista",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Editor",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Redactor creativo",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Presentador / conductor",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Ilustrador",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Diseñador gráfico",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Operador de Cabina 02",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Operador de Cabina 03 y Estudio de Radio",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDescription = "Foto fija",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDescription = "Cámara y asistente de cámara",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDescription = "Cámara 360",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDescription = "Postproductor de imagen",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDescription = "Editor",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDescription = "Sonidista",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDescription = "Postproductor de sonido",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDescription = "Redactor creativo",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDescription = "Presentador / conductor",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDescription = "Animador / infografista",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDescription = "Operador de Cabina 01 Estudio de Grabación",
                        RolLvlId = 2
                    }
                );
            context.SaveChanges();

        }
        private static void SeedTechnicianRoles(ProjectContext context)
        {
            if (context.TechnicianRoles.Any())
            {
                return;   // DB has been seeded
            }

            context.TechnicianRoles.AddRange
            (
             new TechnicianRole
             {
                 TechnicianId = context.Technician.Single(t => t.Name == "Vincent Vega").Id,
                 RoleId = 5
             },
             new TechnicianRole
             {
                 TechnicianId = context.Technician.Single(t => t.Name == "Vincent Vega").Id,
                 RoleId = 1
             },
             new TechnicianRole
             {
                 TechnicianId = context.Technician.Single(t => t.Name == "Vincent Vega").Id,
                 RoleId = 3
             }     
            );
            context.SaveChanges();
        }
    }

}




