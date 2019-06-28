using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Data;
using System;
using System.Linq;

namespace Proyecto.Models
{
    public static class SeedData
    {
        private static void SeedRoleLevels(ProjectContext context)
        {
            // Look for any RoleLevel.
            if (context.RoleLevel.Any())
            {
                return;   // DB has been seeded
            }

            context.RoleLevel.AddRange(
                new RoleLevel
                {
                    RolLevelDescription = "Básico"
                },

                new RoleLevel
                {
                    RolLevelDescription = "Avanzado"
                }
            );
            context.SaveChanges();
        }

        private static void SeedRoles(ProjectContext context)
        {
            // Look for any Role.
            if (context.Role.Any())
            {
                return;   // DB has been seeded
            }

            context.Role.AddRange(
                new Role
                {
                    RolDescription = "Foto fija",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Asistente de cámara",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Asistente de producción",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Asistente de dirección",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Asistente de arte (escenografía, vestuario, utilería)",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Sonidista",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Editor",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Redactor creativo",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Presentador / conductor",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Ilustrador",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Diseñador gráfico",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Operador de Cabina 02",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Operador de Cabina 03 y Estudio de Radio",
                    RolLevelID = 1
                },

                new Role
                {
                    RolDescription = "Foto fija",
                    RolLevelID = 2
                },

                new Role
                {
                    RolDescription = "Cámara y asistente de cámara",
                    RolLevelID = 2
                },

                new Role
                {
                    RolDescription = "Cámara 360",
                    RolLevelID = 2
                },

                new Role
                {
                    RolDescription = "Postproductor de imagen",
                    RolLevelID = 2
                },

                new Role
                {
                    RolDescription = "Editor",
                    RolLevelID = 2
                },

                new Role
                {
                    RolDescription = "Sonidista",
                    RolLevelID = 2
                },

                new Role
                {
                    RolDescription = "Postproductor de sonido",
                    RolLevelID = 2
                },

                new Role
                {
                    RolDescription = "Redactor creativo",
                    RolLevelID = 2
                },

                new Role
                {
                    RolDescription = "Presentador / conductor",
                    RolLevelID = 2
                },

                new Role
                {
                    RolDescription = "Animador / infografista",
                    RolLevelID = 2
                },

                new Role
                {
                    RolDescription = "Operador de Cabina 01 Estudio de Grabación",
                    RolLevelID = 2
                }
            );
            context.SaveChanges();
        }
        private static void SeedHiringCost(ProjectContext context)
        {
           // Look for any Role.
            if (context.HiringCost.Any())
            {
                return;   // DB has been seeded
            }
            context.HiringCost.AddRange(
                new HiringCost 
                {
                    RolLevelID = 1,
                    HiringCostHourly = 380,
                    HiringCostAdditional = 150,
                    HiringCostFull = 1200
                },
                new HiringCost 
                {
                    RolLevelID = 2,
                    HiringCostHourly = 520,
                    HiringCostAdditional = 280,
                    HiringCostFull = 2000
                }
                
            ) ;
            context.SaveChanges();
        }
        /*
        private static void SeedProject(ProjectContext context)
        {
            // Look for any movies.
            if (context.Project.Any())
            {
                return;   // DB has been seeded
            }

            var projects = new Project[]
            {
               new Project
                {
                    Title = "Projecto 1",
                    Description = "Este es el proyecto 1",
                   StartDate = DateTime.Parse("2019-9-16"),
                   EndDate = DateTime.Parse("2019-12-25")
                },

                new Project
                {
                     Title = "Projecto 2",
                    Description = "Este es el proyecto 2",
                   StartDate = DateTime.Parse("2019-9-16"),
                   EndDate = DateTime.Parse("2019-12-25")
                },

                new Project
                {
                     Title = "Projecto 3",
                    Description = "Este es el proyecto 3",
                   StartDate = DateTime.Parse("2019-9-16"),
                   EndDate = DateTime.Parse("2019-12-25")
                }
            };
            foreach(Project p in projects)
            {
                context.Project.Add(p);
            }
            context.SaveChanges();
        }
        private static void SeedTechnician(ProjectContext context)
        {
            // Look for any actor.
            if (context.Technician.Any())
            {
                return;   // DB has been seeded
            }

            var technicians = new Technician[]
            {
                new Technician
                {
                    Name = "Billy Crystal",
                    BirthDate = DateTime.Parse("1948-3-14"),
                    
                },

                new Technician
                {
                    Name = "Meg Ryan",
                    BirthDate = DateTime.Parse("1961-11-19")
                },

                new Technician
                {
                    Name = "Bill Murray",
                    BirthDate = DateTime.Parse("1950-9-21")
                },

                new Technician
                {
                    Name = "Dan Aykroyd",
                    BirthDate = DateTime.Parse("1952-7-1")
                },

                new Technician
                {
                    Name = "Sigourney Weaver",
                    BirthDate = DateTime.Parse("1949-10-8")
                },

                new Technician
                {
                    Name = "John Wayne",
                    BirthDate = DateTime.Parse("1907-5-26")
                },

                new Technician
                {
                    Name = "Dean Martin",
                    BirthDate = DateTime.Parse("1917-7-7")
                }
            };
            foreach(Technician t in technicians)
            {
                context.Technician.Add(t);
            }
            context.SaveChanges();
        }

        private static void SeedPostulation(ProjectContext context)
        {
            // Look for any appereance.
            if (context.Postulation.Any())
            {
                return;   // DB has been seeded
            }

            var Postulation = new Postulation[]
            {
                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Billy Crystal").TechnicianID,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto 1").ProjectID                       
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Meg Ryan").TechnicianID,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto 2").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Bill Murray").TechnicianID,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto 3").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Dan Aykroyd").TechnicianID,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto 1").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Sigourney Weaver").TechnicianID,
                    ProjectID = context.Project.Single(m => m.Title == "proyecto 2").ProjectID
                },

                
            };

            foreach (Postulation a in Postulation)
            {
                context.Postulation.Add(a);
            }
            context.SaveChanges();
        }
        */
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProjectContext>>()))
            {
                SeedRoleLevels(context);
                SeedRoles(context);
                SeedHiringCost(context);
                /*SeedProject(context);
                SeedTechnician(context);
                SeedPostulation(context);*/
            }
        }
        
    }
}