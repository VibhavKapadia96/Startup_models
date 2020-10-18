using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Startup_blazor.Data;

[assembly: HostingStartup(typeof(Startup_blazor.Areas.Identity.IdentityHostingStartup))]
namespace Startup_blazor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Startup_blazorContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Startup_blazorContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Startup_blazorContext>();
            });
        }
    }
}