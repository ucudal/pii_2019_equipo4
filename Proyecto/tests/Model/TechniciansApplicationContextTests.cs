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
           
                var expectedTechnicians = SeedProjectTechnician.GetSeedingTechnicians();
                await db.AddRangeAsync(expectedTechnicians);
                await db.SaveChangesAsync();

                // Act: retrieve seeded Technicians from database
                var result = await db.GetTechniciansAsync();

                // Assert: seeded and retrieved Technicians match
                var actualTechnicians = Assert.IsAssignableFrom<List<Technician>>(result);
                Assert.Equal(
                    expectedTechnicians.Select(a => a.Name),
                    actualTechnicians.Select(a => a.Name));
            }
        }

        [Fact]
        public async Task AddTechnicianAsync_TechnicianIsAdded()
        {
            using (var db = new ProjectContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var recId = "10";
                var expectedTechnician = new Technician() { Id = recId, Name = "Juana" };

                // Act
                await db.AddTechnicianAsync(expectedTechnician);

                // Assert
                var actualTechnician = await db.FindAsync<Technician>(recId);
                Assert.Equal(expectedTechnician, actualTechnician);
            }
        }
    }
}