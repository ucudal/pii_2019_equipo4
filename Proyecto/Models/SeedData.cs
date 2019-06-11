using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Proyecto.Data;

namespace Proyecto.Models
{
    public static class SeedDataProject
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProjectContext>>()))
            {
                SeedTechnician(context);
                SeedProject(context);
                SeedPostulation(context);
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
            );
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
                    TechnicianID = context.Technician.Single(a => a.Name == "Billy Crystal").ID,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto 1").ProjectID                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Meg Ryan").ID,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto 2").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Bill Murray").ID,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto 3").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Dan Aykroyd").ID,
                    ProjectID = context.Project.Single(m => m.Title == "Proyecto 1").ProjectID
                },

                new Postulation
                {
                    TechnicianID = context.Technician.Single(a => a.Name == "Sigourney Weaver").ID,
                    ProjectID = context.Project.Single(m => m.Title == "proyecto 2").ProjectID
                },

                
            };

            foreach (Postulation a in Postulation)
            {
                context.Postulation.Add(a);
            }
            context.SaveChanges();
        }
    }
}


