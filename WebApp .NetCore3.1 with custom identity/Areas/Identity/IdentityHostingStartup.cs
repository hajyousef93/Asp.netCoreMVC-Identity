using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp_.NetCore3._1_with_custom_identity.Data;

[assembly: HostingStartup(typeof(WebApp_.NetCore3._1_with_custom_identity.Areas.Identity.IdentityHostingStartup))]
namespace WebApp_.NetCore3._1_with_custom_identity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}