using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Proyecto.Models;
using Proyecto.Data;
using Proyecto.Areas.Identity.Data;


namespace Proyecto.Tests
{
    public class TechsApplicationContextTests
    {
        [Fact]
        public async Task TechniciansAreRetrievedTest()
        {
            using (var db = new ProjectContext(Utilities.TestDbContextOptions()))
            {
                // Arrange: seed database with Technicians
           
                var expectedTechnicians = SeedProjTech.GetSeedingTechnicians();
                await db.AddRangeAsync(expectedTechnicians);
                await db.SaveChangesAsync();

                // Act: retrieve seeded Technicians from database
                var result = await db.GetTechniciansAsync();

                // Assert: seeded and retrieved Technicians match
                var actualTechnicians = Assert.IsAssignableFrom<List<Technician>>(result);
                Assert.Equal(
                    expectedTechnicians.OrderBy(a => a.ID).Select(a => a.Name),
                    actualTechnicians.OrderBy(a => a.ID).Select(a => a.Name));
            }
        }
    }
}