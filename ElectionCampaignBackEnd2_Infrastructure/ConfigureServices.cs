using ElectionCampaignBackEnd2_Application.Interfaces;
using ElectionCampaignBackEnd2_Application.Repository;
using ElectionCampaignBackEnd2_Application;
using ElectionCampaignBackEnd2_Application.Services;
using ElectionCampaignBackEnd2_Infrastructure.DataContext;
using ElectionCampaignBackEnd2_Infrastructure.Repositories;
using ElectionCampaignBackEnd2_Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionCampaignBackEnd2_Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("HR_clean_demo"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("HR_clean_demo"),
                        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<ApplicationDbContextInitialiser>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserMasterRepository, UserMasterRepository>();

            services.AddScoped<IUsermasterService, UsermasterService>();
            return services;
        }
    }
}
