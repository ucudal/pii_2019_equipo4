using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Data;
using Proyecto.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Proyecto.Areas.Identity.IdentityHostingStartup))]
namespace Proyecto.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            /* services.AddDbContext<ProyectoIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("ProjectContext")));*/
            builder.ConfigureServices((context, services) => {
                

                services.AddDefaultIdentity<ApplicationUser>().AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ProyectoIdentityDbContext>();
            });
        }
    }
}