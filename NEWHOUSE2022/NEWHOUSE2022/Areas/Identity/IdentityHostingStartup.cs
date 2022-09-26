using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NEWHOUSE2022.Data;

[assembly: HostingStartup(typeof(NEWHOUSE2022.Areas.Identity.IdentityHostingStartup))]
namespace NEWHOUSE2022.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NEWHOUSE2022Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NEWHOUSE2022ContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<NEWHOUSE2022Context>();
            });
        }
    }
}