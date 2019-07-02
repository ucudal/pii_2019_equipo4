using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Xunit;
using Proyecto.Models;
using Proyecto.Pages_Projects;
using Proyecto.Data;
using Proyecto.Areas.Identity.Data;

namespace Proyecto.Tests
{/*    public class ProjectsIndexPageTests
    {
        // A delegate to perform a test action using a pre-configured ProjectContext
        private delegate Task TestAction(ProjectContext context);

        // Creates and seeds an ProjectContext with test data; then calls  test action.
        private async Task PrepareTestContext(TestAction testAction)
        {
            // Database is in memory as long the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            try
            {
                connection.Open();

                var options = new DbContextOptionsBuilder<ProjectContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database and seeds with test data
                using (var context = new ProjectContext(options))
                {
                    context.Database.EnsureCreated();
                    SeedProjectTech.Initialize(context);

                    await testAction(context);
                }
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public async Task OnGetAsyncPopulatesPageModel()
        {
            // Arrange: seed database with test data
            await PrepareTestContext(async(context) =>
            {
                    var expectedProjects = SeedProjectTech.GetSeedingProjects();
                    
                    // Act: retrieve Projects
                    var pageModel = new IndexModel(context);
                    await pageModel.OnGetAsync();

                    // Assert: seeded and retrieved Projects match
                    var actualMessages = Assert.IsAssignableFrom<List<Project>>(pageModel.Project);
                    Assert.Equal(
                        expectedProjects.OrderBy(a => a.ProjectID).Select(a => a.Title),
                        actualMessages.OrderBy(a => a.ProjectID).Select(a => a.Title));
            });
        }
    } */
}