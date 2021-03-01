using System;
using CarDealerManager.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CarDealerManager.Areas.Identity.IdentityHostingStartup))]
namespace CarDealerManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CarDealerManagerIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CarDealerManagerIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CarDealerManagerIdentityContext>();
            });
        }
    }
}