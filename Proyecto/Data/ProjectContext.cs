using Microsoft.EntityFrameworkCore;
using Proyecto.Areas.Identity.Data;
using Proyecto.Models;

namespace Proyecto.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Postulation>().ToTable("Postulants").HasKey(t => new {t.TechnicianID,t.ProjectID});
        }
        
        
        public DbSet<ApplicationUser> ApplicationUser {get;set;}
        //public DbSet<Proyecto.Models.RoleLevel> RoleLevel {get;set;}
        //public DbSet<Proyecto.Models.Role> Role {get;set;}
        public DbSet<Proyecto.Models.Project> Project { get; set; }

        public DbSet<Proyecto.Models.RoleLevel> RoleLevel {get;set;}
        public DbSet<Proyecto.Models.Role> Role {get;set;}
        public DbSet<Proyecto.Models.Technician> Technician{get;set;}
         public DbSet<Proyecto.Models.Postulation> Postulation{get;set;}

         public DbSet<Proyecto.Models.HiringCost> HiringCost{get;set;}
    }
}
