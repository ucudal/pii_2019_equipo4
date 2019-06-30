using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Proyecto.Data;

namespace Proyecto.Models
{
    public static class SeedProjectTechnician
    {

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

            context.Project.AddRange(
                new Project
                {
                    ProjectID = 1,
                    Title = "When Harry Met Sally",
                    Description ="prueba1",
                    StartDate = DateTime.Parse("1989-2-12"),
                    EndDate =DateTime.Parse("2000-2-12")
                    
                },

                new Project
                {
                    ProjectID = 2,
                    Title = "Ghostbusters",
                    Description ="prueba1",
                    StartDate = DateTime.Parse("1989-2-12"),
                    EndDate =DateTime.Parse("2000-2-12")
                },

                new Project
                {
                    ProjectID = 3,
                    Title = "Ghostbusters 2",
                    Description ="prueba1",
                    StartDate = DateTime.Parse("1989-2-12"),
                    EndDate =DateTime.Parse("2000-2-12")
                },

                new Project
                {
                    ProjectID = 4,
                    Title = "Rio Bravo",
                    Description ="prueba1",
                    StartDate = DateTime.Parse("1989-2-12"),
                    EndDate =DateTime.Parse("2000-2-12")
                }
            );
            context.SaveChanges();
        }

        private static void SeedTechnician(ProjectContext context)
        {
            // Look for any actor.
            if (context.Technician.Any())
            {
                return;   // DB has been seeded
            }

            context.Technician.AddRange(
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
            );
            context.SaveChanges();
        }

        private static void SeedPostulations(ProjectContext context)
        {
            // Look for any appereance.
            if (context.Postulation.Any())
            {
                return;   // DB has been seeded
            }

            var postulations = new Postulation[]
            {
                new Postulation
                {
                    TechnicianID = context.Technician.Single(t => t.Name == "Bill Murray").ID,
                    ProjectID = context.Project.Single(m => m.Title == "When Harry Met Sally").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Meg Ryan").ID,
                    ProjectID = context.Project.Single(m => m.Title == "When Harry Met Sally").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Bill Murray").ID,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Dan Aykroyd").ID,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Sigourney Weaver").ID,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Bill Murray").ID,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters 2").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Dan Aykroyd").ID,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters 2").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Sigourney Weaver").ID,
                    ProjectID = context.Project.Single(m => m.Title == "Ghostbusters 2").ProjectID
                },

                 new Postulation
                 {
                     TechnicianID = context.Technician.Single(a => a.Name == "John Wayne").ID,
                     ProjectID = context.Project.Single(m => m.Title == "Rio Bravo").ProjectID
                 },

                 new Postulation {
                     TechnicianID = context.Technician.Single(a => a.Name == "Dean Martin").ID,
                     ProjectID = context.Project.Single(m => m.Title == "Rio Bravo").ProjectID
                 }
            };

            foreach (Postulation a in postulations)
            {
                context.Postulation.Add(a);
            }
            context.SaveChanges();
        }

        private static void SeedRoleLevel(ProjectContext context)
        {
            if(context.RoleLevel.Any())
            {
                return;
            }
            context.RoleLevel.AddRange(
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
            );
            context.SaveChanges();
        }
    
        }

}




