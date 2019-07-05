using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Xunit;
using Proyecto.Models;
using Proyecto.Pages_Technicians;
using Proyecto.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;


namespace Proyecto.Tests
{
    public class TechniciansIndexPageTests
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
                    SeedProjectTechnician.Initialize(context);

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
                    var expectedTechnicians = SeedProjectTechnician.GetSeedingTechnicians();

                    // Act: retrieve Technicians
                    var pageModel = new IndexModel(context);
                    await pageModel.OnGetAsync();

                    // Assert: seeded and retrieved Technicians match
                    var actualTechnicians = Assert.IsAssignableFrom<List<Technician>>(pageModel.Technician);
                    Assert.Equal(
                        expectedTechnicians.Select(a => a.Name),
                        actualTechnicians.Select(a => a.Name));
            });
        }
    }
}