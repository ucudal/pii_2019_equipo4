using Microsoft.EntityFrameworkCore;
using Proyecto.Areas.Identity.Data;

namespace Proyecto.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }
       /* protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        */
        
        public DbSet<Technician> Technician {get;set;}
        //public DbSet<Proyecto.Models.RoleLevel> RoleLevel {get;set;}
        //public DbSet<Proyecto.Models.Role> Role {get;set;}
        public DbSet<Proyecto.Models.Project> Project { get; set; }

        public DbSet<Proyecto.Models.RoleLevel> RoleLevel {get;set;}
        public DbSet<Proyecto.Models.Role> Role {get;set;}

    }
}
