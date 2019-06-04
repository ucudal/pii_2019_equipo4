using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto.Models.Project> Project { get; set; }
    }
}