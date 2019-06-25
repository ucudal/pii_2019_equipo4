using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Areas.Identity.Data;
using Proyecto.Data;

[assembly: HostingStartup(typeof(Proyecto.Areas.Identity.IdentityHostingStartup))]
namespace Proyecto.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDefaultIdentity<ApplicationUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ProjectContext>();
            });
        }
    }
}