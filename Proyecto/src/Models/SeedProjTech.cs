using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Proyecto.Data;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public static class SeedProjTech
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

        private static void SeedRoleLevel(ProjectContext context)
        {
            if(context.RoleLevel.Any())
            {
                return;
            }

            foreach (RoleLevel a in GetSeedingRoleLevels(context))
            {
                context.RoleLevel.Add(a);

            }
            context.RoleLevel.AddRange(GetSeedingRoleLevels(context));           
            context.SaveChanges();
        }

        public static List<RoleLevel> GetSeedingRoleLevels(ProjectContext context)
        {
            return new List<RoleLevel>()
            {
                new RoleLevel
                {
                    ProjectID = context.Project.Single(m => m.Title == "When Harry Met Sally").ProjectID,
                    roleLevel = "Básico"
                },

                new RoleLevel
                {
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters").ProjectID,
                    roleLevel = "Avanzado"
                },

                new RoleLevel
                {
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters 2").ProjectID,
                    roleLevel = "Avanzado"
                },

                new RoleLevel
                {
                    ProjectID = context.Project.Single(m => m.Title == "Rio Bravo").ProjectID,
                    roleLevel = "Básico"
                }

            };
        }
        


        
    
        }

}




