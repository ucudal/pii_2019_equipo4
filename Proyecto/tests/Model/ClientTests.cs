using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Proyecto.Models;
using Proyecto.Data;
using Proyecto.Areas.Identity.Data;


namespace Proyecto.Tests
{
    public class ClientsApplicationContextTests
    {
        [Fact]
        public async Task ClientsAreRetrievedTest()
        {
            using (var db = new ProjectContext(Utilities.TestDbContextOptions()))
            {
                // Arrange: seed database with Clients
           
                var expectedClients = SeedProjectTechnician.GetSeedingClients();
                await db.AddRangeAsync(expectedClients);
                await db.SaveChangesAsync();

                // Act: retrieve seeded Clients from database
                var result = await db.GetClientAsync();

                // Assert: seeded and retrieved Clients match
                var actualClients = Assert.IsAssignableFrom<List<Client>>(result);
                Assert.Equal(
                    expectedClients.Select(a => a.Name),
                    actualClients.Select(a => a.Name));
            }
        }
        [Fact]
        public async Task AddClientAsync_ClientIsAdded()
        {
            using (var db = new ProjectContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var recId = "10";
                var expectedClient = new Client() { Id = recId, Name = "Juan" };

                // Act
                await db.AddClientAsync(expectedClient);

                // Assert
                var actualClient = await db.FindAsync<Client>(recId);
                Assert.Equal(expectedClient, actualClient);
            }
        }
    }
}