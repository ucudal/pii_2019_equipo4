using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class TechnicianRoleContext : DbContext
    {
        public TechnicianRoleContext(DbContextOptions<TechnicianRoleContext> options) : base(options)
        {

        }
        public DbSet<TechnicianRole> TechnicianRole { get; set; }
    }
}
