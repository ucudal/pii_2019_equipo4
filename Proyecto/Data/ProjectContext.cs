using Microsoft.EntityFrameworkCore;
using Proyecto.Areas.Identity.Data;
using Proyecto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Proyecto.Data
{
    public class ProjectContext : IdentityDbContext<ApplicationUser>
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
            builder.Entity<Postulation>().HasKey(t => new {t.TechnicianID,t.ProjectID});
            builder.Entity<Postulation>().HasOne (proj => proj.Project).WithMany(post => post.Postulants).HasForeignKey(proj => proj.ProjectID);
            builder.Entity<Postulation>().HasOne(tech => tech.Technician).WithMany(post => post.Postulants).HasForeignKey(tech => tech.TechnicianID);
        
            //builder.Entity<Role>().HasKey(t => new Role{t.TechnicianID, t.ProjectID});
            //builder.Entity<Role>().HasOne(proj => proj.Project).WithMany(rol => rol.RoleLevel)
        }
        
        
        
        //public DbSet<Proyecto.Models.RoleLevel> RoleLevel {get;set;}
        //public DbSet<Proyecto.Models.Role> Role {get;set;}
        public DbSet<Proyecto.Models.Project> Project { get; set; }

        public DbSet<Proyecto.Models.RoleLevel> RoleLevel {get;set;}
        public DbSet<Proyecto.Models.Technician> Technician{get;set;}
         public DbSet<Proyecto.Models.Postulation> Postulation{get;set;}

         
    }
}
