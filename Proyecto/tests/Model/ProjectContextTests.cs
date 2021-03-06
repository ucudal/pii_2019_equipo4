using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Proyecto.Models;
using Proyecto.Data;
using Proyecto.Areas.Identity.Data;


namespace Proyecto.Tests
{
    public class ProjsApplicationContextTests
    {
        [Fact]
        public async Task ProjectsAreRetrievedTest()
        {
            using (var db = new ProjectContext(Utilities.TestDbContextOptions()))
            {
                // Arrange: seed database with Technicians
           
                var expectedProjects = SeedProjectTechnician.GetSeedingProjects();
                await db.AddRangeAsync(expectedProjects);
                await db.SaveChangesAsync();

                // Act: retrieve seeded Projects from database
                var result = await db.GetProjectsAsync();

                // Assert: seeded and retrieved Projects match
                var actualProjects = Assert.IsAssignableFrom<List<Project>>(result);
                Assert.Equal(
                    expectedProjects.OrderBy(a => a.ProjectID).Select(a => a.Title),
                    actualProjects.OrderBy(a => a.ProjectID).Select(a => a.Title));
            }
        }

        [Fact]
        public async Task AddProjectAsync_ProjectIsAdded()
        {
            using (var db = new ProjectContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var recId = "10";
                var expectedProject = new Project() { ProjectID = recId, Title = "Juana" };

                // Act
                await db.AddProjectAsync(expectedProject);

                // Assert
                var actualProject = await db.FindAsync<Project>(recId);
                Assert.Equal(expectedProject, actualProject);
            }
        }
    }
}