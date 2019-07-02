using Microsoft.EntityFrameworkCore;
using Proyecto.Areas.Identity.Data;
using Proyecto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
        
            
            
        }
        
        
        
        //public DbSet<Proyecto.Models.RoleLevel> RoleLevel {get;set;}
        //public DbSet<Proyecto.Models.Role> Role {get;set;}
        public DbSet<Proyecto.Models.Project> Project { get; set; }

        public DbSet<Proyecto.Models.RoleLevel> RoleLevel {get;set;}
        public DbSet<Proyecto.Models.Technician> Technician{get;set;}
        public DbSet<Proyecto.Models.Client> Client {get;set;}
        public DbSet<Proyecto.Models.Postulation> Postulation{get;set;}
        public async virtual Task<List<Proyecto.Models.Technician>> GetTechniciansAsync()
        {
            return await this.Technician
                .AsNoTracking()
                .ToListAsync();
        }
        public async virtual Task<List<Proyecto.Models.Project>> GetProjectsAsync()
        {
            return await this.Project
                .AsNoTracking()
                .ToListAsync();
        }
        public async virtual Task<List<Proyecto.Models.RoleLevel>> GetRoleLevelsAsync()
        {
            return await this.RoleLevel
                .AsNoTracking()
                .ToListAsync();
        }
        public bool TechnicianExists(string id)
        {
            return this.Technician.Any(e => e.Id == id);
        }

        public async virtual Task<List<Technician>> GetTechnicianAsync()
        {
            return await this.Technician
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Technician> GetTechnicianByIdAsync(string id)
        {
            return this.Technician.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task<int> AddTechnicianAsync(Technician Technician)
        {
            this.Technician.Add(Technician);
            return this.SaveChangesAsync();
        }

        public Task<int> RemoveTechnicianAsync(Technician Technician)
        {
            this.Technician.Remove(Technician);
            return this.SaveChangesAsync();
        }

        public bool ProjectExists(string id)
        {
            return this.Project.Any(e => e.ProjectID == id);
        }

        public async virtual Task<List<Project>> GetProjectAsync()
        {
            return await this.Project
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Project> GetProjectByIdAsync(string id)
        {
            return this.Project.FirstOrDefaultAsync(m => m.ProjectID == id);
        }

        public Task<int> AddProjectAsync(Project Project)
        {
            this.Project.Add(Project);
            return this.SaveChangesAsync();
        }

        public Task<int> RemoveProjectAsync(Project Project)
        {
            this.Project.Remove(Project);
            return this.SaveChangesAsync();
        }

         
    }
}
