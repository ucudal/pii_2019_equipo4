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
                    Title = "When Harry Met Sally",
                    Description ="prueba1 ",
                    StartDate = DateTime.Parse("1989-2-12"),
                    EndDate =DateTime.Parse("2000-2-12")

                },

                new Project
                {
                    Title = "Ghostbusters",
                    Description ="prueba1 ",
                    StartDate = DateTime.Parse("1989-2-12"),
                    EndDate =DateTime.Parse("2000-2-12")
                },

                new Project
                {
                    Title = "Ghostbusters 2",
                    Description ="prueba1 ",
                    StartDate = DateTime.Parse("1989-2-12"),
                    EndDate =DateTime.Parse("2000-2-12")
                },

                new Project
                {

                    Title = "Rio Bravo",
                    Description ="prueba1 ",
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

                    Name = "Billy Crystal",
                    BirthDate = DateTime.Parse("1948-3-14")

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
                    TechnicianID = context.Technician.Single(t => t.Name == "Bill Murray").Id,
                    ProjectID = context.Project.Single(m => m.Title == "When Harry Met Sally").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Meg Ryan").Id,
                    ProjectID = context.Project.Single(m => m.Title == "When Harry Met Sally").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Bill Murray").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Dan Aykroyd").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Sigourney Weaver").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Bill Murray").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters 2").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Dan Aykroyd").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters 2").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Sigourney Weaver").Id,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters 2").ProjectID
                },

                 new Postulation
                 {
                     TechnicianID = context.Technician.Single(a => a.Name == "John Wayne").Id,
                     ProjectID = context.Project.Single(m => m.Title == "Rio Bravo").ProjectID
                 },

                 new Postulation {
                     TechnicianID = context.Technician.Single(a => a.Name == "Dean Martin").Id,
                     ProjectID = context.Project.Single(m => m.Title == "Rio Bravo").ProjectID
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
                        RolLvlDsc = "Básico"
                    },

                    new RoleLevel
                    {
                        RolLvlDsc = "Avanzado"
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
                        RolDsc = "Foto fija",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Asistente de cámara",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Asistente de producción",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Asistente de dirección",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Asistente de arte (escenografía, vestuario, utilería)",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Sonidista",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Editor",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Redactor creativo",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Presentador / conductor",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Ilustrador",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Diseñador gráfico",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Operador de Cabina 02",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Operador de Cabina 03 y Estudio de Radio",
                        RolLvlId = 1
                    },

                    new Role
                    {
                        RolDsc = "Foto fija",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDsc = "Cámara y asistente de cámara",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDsc = "Cámara 360",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDsc = "Postproductor de imagen",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDsc = "Editor",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDsc = "Sonidista",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDsc = "Postproductor de sonido",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDsc = "Redactor creativo",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDsc = "Presentador / conductor",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDsc = "Animador / infografista",
                        RolLvlId = 2
                    },

                    new Role
                    {
                        RolDsc = "Operador de Cabina 01 Estudio de Grabación",
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
                 TechnicianId = context.Technician.Single(t => t.Name == "Bill Murray").Id,
                 RoleId = 5
             },
             new TechnicianRole
             {
                 TechnicianId = context.Technician.Single(t => t.Name == "Bill Murray").Id,
                 RoleId = 1
             },
             new TechnicianRole
             {
                 TechnicianId = context.Technician.Single(t => t.Name == "Bill Murray").Id,
                 RoleId = 3
             }     
            );
            context.SaveChanges();
        }
    }

}




